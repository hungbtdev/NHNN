using KTApps.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KTApps.Core.App
{
    public class ExceptionActionFilter : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ExceptionActionFilter(
            IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        #region Overrides of ExceptionFilterAttribute

        public override void OnException(ExceptionContext context)
        {
            var actionDescriptor = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            Type controllerType = actionDescriptor.ControllerTypeInfo;

            var controllerBase = typeof(ControllerBase);
            var controller = typeof(Controller);
            bool isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            // Api's implements ControllerBase but not Controller
            if (controllerType.IsSubclassOf(controllerBase) && !controllerType.IsSubclassOf(controller) ||
                (controllerType.IsSubclassOf(controllerBase) && controllerType.IsSubclassOf(controller) && isAjaxCall)
                )
            {
                string message = string.Empty;
                KTAppDomainResult appDomainResult = new KTAppDomainResult();
                if (_hostingEnvironment.IsDevelopment())
                {
                    message = context.Exception.ToString();
                }
                else
                {
                    if (context.Exception is KTAppException)
                    {
                        appDomainResult.ResultCode = (context.Exception as KTAppException).ErrorCode;
                        if ((context.Exception as KTAppException).ErrorCode == 0)
                        {
                            message = "An error has occurred. Contact your administrator for further assistance";
                        }
                        else
                        {
                            message = context.Exception.Message + " ErrorCode:" + (context.Exception as KTAppException).ErrorCode;
                        }
                    }
                    else
                    {
                        message = context.Exception.Message;
                    }
                }
                appDomainResult.Messages.Add(message);
                // Handle web api exception
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = 200;
                context.Result = new ObjectResult(appDomainResult);
            }

            base.OnException(context);
        }

        #endregion
    }

}

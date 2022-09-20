using Vinorsoft.Core.App.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.App.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class VinorsoftAuthorize2Attribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] Permissions;
        private readonly bool AllowAnonymous;

        public VinorsoftAuthorize2Attribute(string[] permission = null, bool allowAnonymous = false)
        {
            Permissions = permission;
            AllowAnonymous = allowAnonymous;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (AllowAnonymous)
            {
                return;
            }
            if (Permissions == null || Permissions.Length <= 0)
            {
                //context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                context.Result = new RedirectToActionResult("Index", "Error", new { Area = "System", errorCode = 403, ReturnUrl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}" });
                return;
            }

            var user = context.HttpContext.User;
            string controllerName = string.Empty;
            if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                controllerName = descriptor.ControllerName;
            }

            if (!user.Identity.IsAuthenticated)
            {
                if (controllerName != "Login")
                {
                    context.Result = new RedirectToActionResult("Index", "Login", new { Area = "System", ReturnUrl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}" });
                }
                //context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                //context.Result = new RedirectToActionResult("Index", "Login", new {Area="System", ReturnUrl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}" });
                return;
            }

            IUserService userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));
            var hasPermit = false;
            if (userService.IsLocked(LoginContext.Instance.CurrentUser.UserId))
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                context.Result = new RedirectToActionResult("Index", "Login", new { Area = "System", ReturnUrl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}" });
                return;
            }

            hasPermit = userService.HasPermission(LoginContext.Instance.CurrentUser.UserId, controllerName, Permissions);

            if (!hasPermit)
            {
                //context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                context.Result = new RedirectToActionResult("Index", "Error", new { Area = "System", errorCode = 403, ReturnUrl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}" });
                return;
            }

        }
    }
}

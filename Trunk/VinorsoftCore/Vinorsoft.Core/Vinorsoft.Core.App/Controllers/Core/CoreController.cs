using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.App.Controllers
{
    public abstract class CoreController : Controller
    {
        protected readonly ILogger<Controller> logger;
        private readonly IUserService userService;
        public CoreController(IServiceProvider serviceProvider)
        {
            logger = serviceProvider.GetRequiredService<ILogger<Controller>>();
            userService = serviceProvider.GetRequiredService<IUserService>();
        }
        protected void SetError(string err)
        {
            ViewData["Error"] = err;
        }

        protected void HandleError(Exception ex)
        {
            SetError(ex.Message);
            logger.LogError(ex, ex.Message, new string[] { });
        }
        protected virtual PermitGridOptionDTO GetPermitGridOption()
        {
            var userId = LoginContext.Instance.CurrentUser.UserId;
            var controler = ControllerContext.ActionDescriptor.ControllerName;
            return new PermitGridOptionDTO()
            {
                EnableAdd = userService.HasPermission(userId, controler, new string[] { CoreConstants.AddNew }),
                EnableCancel = userService.HasPermission(userId, controler, new string[] { CoreConstants.Cancel }),
                EnableCopy = userService.HasPermission(userId, controler, new string[] { CoreConstants.Copy }),
                EnableDelete = userService.HasPermission(userId, controler, new string[] { CoreConstants.Delete }),
                EnableDownload = userService.HasPermission(userId, controler, new string[] { CoreConstants.Download }),
                EnableEdit = userService.HasPermission(userId, controler, new string[] { CoreConstants.Edit }),
                EnableExport = userService.HasPermission(userId, controler, new string[] { CoreConstants.Export }),
                EnableImport = userService.HasPermission(userId, controler, new string[] { CoreConstants.Import }),
                EnablePrint = userService.HasPermission(userId, controler, new string[] { CoreConstants.Print }),
            };
        }

        protected IActionResult Error(string errorCode)
        {
            return RedirectToAction("Index", "Error", new { Area = "System", errorCode = errorCode });
        }
    }
}
using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.App.Extensions;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [Description("Đổi mật khẩu")]
    [Authorize]
    [Area("System")]
    [Authorize]
    public class ChangePasswordController : Controller
    {
        protected readonly IUserService userService;
        ILogger<ChangePasswordController> logger;
        public ChangePasswordController(IUserService userService, ILogger<ChangePasswordController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ChangePasswordDTO());
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordDTO changePassword)
        {
            try
            {
                if (!TryValidateModel(changePassword))
                {
                    SetError(ModelState.GetFullErrorMessage());
                }
                else
                {
                    bool success = userService.ChangePassword(LoginContext.Instance.CurrentUser.UserName, changePassword.Password, changePassword.NewPassword, changePassword.ConfirmPassword);
                    if (success)
                    {
                        return RedirectToAction("Logout", "Login", new { Area = "System" });
                    }
                    else
                    {
                        SetError(CoreErrorResource.ERROR_UNKNOWN);
                    }
                }
            }
            catch (Exception ex)
            {
                SetError(ModelState.GetFullErrorMessage());
                logger.LogError(ex, ex.Message, new string[] { });
            }

            return View("Index", changePassword);
        }

        private void SetError(string err)
        {
            ViewData["Error"] = err;
        }
    }
}
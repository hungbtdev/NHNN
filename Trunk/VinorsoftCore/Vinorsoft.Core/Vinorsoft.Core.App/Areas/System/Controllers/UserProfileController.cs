using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vinorsoft.Core.App.Context;
using Vinorsoft.Core.App.Extensions;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [Description("Cập nhật thông tin người dùng")]
    [Authorize]
    [Area("System")]
    public class UserProfileController : Controller
    {
        protected readonly IUserService userService;
        ILogger<ChangePasswordController> logger;
        public UserProfileController(IUserService userService, ILogger<ChangePasswordController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = userService.GetById(LoginContext.Instance.CurrentUser.UserId);
            if (user == null || user.Id != LoginContext.Instance.CurrentUser.UserId)
            {
                SetError(string.Format(CoreErrorResource.ERROR_NOT_FOUND, LoginContext.Instance.CurrentUser.UserId));
            }
            return View(new UserProfileDTO()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone
            });
        }

        [HttpPost]
        public IActionResult UpdateProfile(UserProfileDTO userProfile)
        {
            try
            {
                if (!TryValidateModel(userProfile))
                {
                    SetError(ModelState.GetFullErrorMessage());
                }
                else
                {
                    bool success = userService.UpdateProfileUser(new Users()
                    {
                        Id = userProfile.Id,
                        FirstName = userProfile.FirstName,
                        LastName = userProfile.LastName,
                        Email = userProfile.Email,
                        Phone = userProfile.Phone
                    });
                    if (!success)
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

            return RedirectToAction ("Index");
        }

        private void SetError(string err)
        {
            ViewData["Error"] = err;
        }
    }
}
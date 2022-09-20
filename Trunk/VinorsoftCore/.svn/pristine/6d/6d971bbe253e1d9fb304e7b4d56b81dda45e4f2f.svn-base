using KTApps.AuthService.Interface;
using KTApps.Core.App.Context;
using KTApps.Core.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace KTApps.Core.App.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class KTAppAuthorize2Attribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] Permissions;

        public KTAppAuthorize2Attribute(string[] permission)
        {
            Permissions = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            string controllerName = string.Empty;
            if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                controllerName = descriptor.ControllerName;
            }

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", new { ReturnUrl = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}" });
                return;
            }

            IUserService userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));
            IConfiguration configuration = (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));
            var hasPermit = false;
            if (userService.IsLocked(LoginContext.Instance.CurrentUser.UserId))
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
                return;
            }

#if DEBUG
            var appSettingsSection = configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            if (appSettings != null && appSettings.GrantPermissionDebug)
            {
                hasPermit = true;
            }
            else
            {
                hasPermit = userService.HasPermission(LoginContext.Instance.CurrentUser.UserId, controllerName, Permissions);
            }
#else
            hasPermit = userService.HasPermission(LoginContext.Instance.CurrentUser.UserId, controllerName, Permissions);
#endif

            if (!hasPermit)
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }

        }
    }
}

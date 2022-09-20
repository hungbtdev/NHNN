using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Vinorsoft.Core.App.Attribute;
using Vinorsoft.Core.App.Controllers;
using Vinorsoft.Core.App.Extensions;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Core.App.Areas.System.Controllers
{
    [Area("System")]
    [Description("Đăng nhập")]
    [AllowAnonymous]
    [VinorsoftAuthorize2(allowAnonymous: true)]
    public class LoginController : VinorsoftCoreController<UserDTO, Users>
    {
        protected readonly IUserService userService;
        private readonly IOptions<AppSettings> configuration;
        public LoginController(IServiceProvider serviceProvider, IMapper mapper, IOptions<AppSettings> configuration) : base(serviceProvider, mapper)
        {
            coreService = serviceProvider.GetRequiredService<IUserService>();
            userService = serviceProvider.GetRequiredService<IUserService>();
            this.configuration = configuration;
        }

        [ActionName("Index2")]
        public override IActionResult Index()
        {
            return base.Index();
        }

        [HttpGet]
        [AllowAnonymous]
        [VinorsoftAuthorize2(allowAnonymous: true)]
        public IActionResult Index(string ReturnUrl)
        {
            return View(new LoginDTO()
            {
                ReturnUrl = ReturnUrl,
                SubDomain = configuration.Value.SubDomain
            });
        }

        [HttpPost]
        [ActionName("Login")]
        [AllowAnonymous]
        [VinorsoftAuthorize2(allowAnonymous: true)]
        public virtual async Task<IActionResult> LoginAsync(LoginDTO login)
        {
            try
            {
                if (!TryValidateModel(login))
                {
                    SetError(ModelState.GetFullErrorMessage());
                    return View("Index", login);
                }

                bool success = userService.Verify(login.UserName, login.Password, null);
                if (success)
                {
                    var user = userService.Get(e => e.Username == login.UserName).FirstOrDefault();
                    var claims = new[] {
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(new CachingLoginDTO {
                                UserId = user.Id,
                                UserName = user.Username,
                                FullName = $"{user.FirstName} { user.LastName}"
                            }))
                        };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    /*
                     * TODO: chưa check trường hợp ReturnUrl = Url page hiện tại => loop
                     */
                    if (!string.IsNullOrEmpty(login.ReturnUrl))
                        return Redirect(login.ReturnUrl);
                    else
                        return RedirectToAction("Index", "Home", new { Area = "" });
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            return View("Index", login);
        }

        [HttpGet]
        [ActionName("LogOut")]
        [Authorize]
        public virtual async Task<IActionResult> LogOutAsync(string returnUrl)
        {
            try
            {
                await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme);
                foreach (var cookie in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(cookie);
                }
                return RedirectToAction("Index", new LoginDTO());
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", new LoginDTO()
                {
                    ReturnUrl = returnUrl
                });
            }

            return RedirectToAction("Index", "Home", new { Area = string.Empty });

        }
    }
}
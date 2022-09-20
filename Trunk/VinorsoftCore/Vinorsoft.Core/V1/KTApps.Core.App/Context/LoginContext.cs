using KTApps.Core.App.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;

namespace KTApps.Core.App.Context
{
    public sealed class LoginContext
    {
        private static LoginContext instance = null;

        private LoginContext()
        {
        }

        public static LoginContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginContext();
                }
                return instance;
            }
        }

        public UserLoginModel CurrentUser
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var claim = HttpContext.Current.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.UserData);
                    if (claim != null)
                    {
                        return JsonConvert.DeserializeObject<UserLoginModel>(claim.Value);
                    }
                }
                return null;
            }
        }

        public void Clear()
        {
            instance = null;
        }

        public UserLoginModel GetCurrentUser(IHttpContextAccessor httpContext)
        {
            if (httpContext != null && httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var claim = httpContext.HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.UserData);
                if (claim != null)
                {
                    return JsonConvert.DeserializeObject<UserLoginModel>(claim.Value);
                }
            }
            return null;
        }
    }
}

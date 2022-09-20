using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.App.Context
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

        public CachingLoginDTO CurrentUser
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var claim = HttpContext.Current.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.UserData);
                    if (claim != null)
                    {
                        return JsonConvert.DeserializeObject<CachingLoginDTO>(claim.Value);
                    }
                }
                return null;
            }
        }

        public void Clear()
        {
            instance = null;
        }

        public CachingLoginDTO GetCurrentUser(IHttpContextAccessor httpContext)
        {
            if (httpContext != null && httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var claim = httpContext.HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.UserData);
                if (claim != null)
                {
                    return JsonConvert.DeserializeObject<CachingLoginDTO>(claim.Value);
                }
            }
            return null;
        }
    }
}

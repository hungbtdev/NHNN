using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Interface;

namespace Vinorsoft.Core.Context
{
    public class AuthContext : IAuthContext
    {
        IHttpContextAccessor httpContextAccessor;

        public AuthContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public CachingLoginDTO CurrentUser
        {
            get
            {
                if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    var claim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.UserData);
                    if (claim != null)
                    {
                        return JsonConvert.DeserializeObject<CachingLoginDTO>(claim.Value);
                    }
                }
                return null;
            }
        }
    }
}

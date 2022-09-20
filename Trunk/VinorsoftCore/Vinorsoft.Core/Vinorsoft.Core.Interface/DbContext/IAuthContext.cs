using Vinorsoft.Core.DTO;

namespace Vinorsoft.Core.Interface
{
    public interface IAuthContext
    {
       CachingLoginDTO CurrentUser { get; }
    }
}

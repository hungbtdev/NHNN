using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;


namespace Vinorsoft.Core
{
    public class PermitObjectPermissionService : CoreService<PermitObjectPermissions>, IPermitObjectPermissionService
    {
        public PermitObjectPermissionService(IAuthDbContext coreDbContext) : base(coreDbContext)
        {
        }
    }
}

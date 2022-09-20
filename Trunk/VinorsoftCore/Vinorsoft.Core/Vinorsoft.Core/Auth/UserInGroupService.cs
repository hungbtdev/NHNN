using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;



namespace Vinorsoft.Core
{
    public class UserInGroupService : CoreService<UserInGroups>, IUserInGroupService
    {
        public UserInGroupService(IAuthDbContext coreDbContext) : base(coreDbContext)
        {
        }
    }
}

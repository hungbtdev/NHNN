using System.Linq;
using Vinorsoft.Core.Entities;
using Vinorsoft.Core.Interface;


namespace Vinorsoft.Core
{
    public class UserGroupService : CoreCatalogueService<UserGroups>, IUserGroupService
    {
        public UserGroupService(IAuthDbContext coreDbContext) : base(coreDbContext)
        {
        }

        public override int Update(UserGroups entity)
        {
            //var currentUserIngroups = coreDbContext.Set<UserInGroups>().Where(e => e.GroupId == entity.Id).ToList();
            //foreach (var item in currentUserIngroups)
            //{
            //    coreDbContext.Set<UserInGroups>().Remove(item);
            //}

            var currentPermitItems = coreDbContext.Set<PermitObjectPermissions>().Where(e => e.GroupId == entity.Id);
            foreach (var item in currentPermitItems)
            {
                coreDbContext.Set<PermitObjectPermissions>().Remove(item);
            }

            //if (entity.UserInGroups.Count > 0)
            //{
            //    coreDbContext.Set<UserInGroups>().AddRange(entity.UserInGroups);
            //}

            if (entity.PermitObjectPermissions.Count > 0)
            {
                coreDbContext.Set<PermitObjectPermissions>().AddRange(entity.PermitObjectPermissions);
            }

            entity.UserInGroups = null;
            entity.PermitObjectPermissions = null;
            return base.Update(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace KTApps.Models
{
    public class UserGroupModel : KTAppDomainCatalogueModel
    {
        public UserGroupModel()
        {
            UserInGroups = new List<UserInGroupModel>();
            PermitObjectPermissions = new List<PermitObjectPermissionModel>();
            PermitObjectGroups = new List<PermitObjectPermissionModel>();
        }
        public IList<UserInGroupModel> UserInGroups { set; get; }
        public IList<PermitObjectPermissionModel> PermitObjectPermissions { set; get; }
        public IList<PermitObjectPermissionModel> PermitObjectGroups { set; get; }

        public void ToView()
        {
            PermitObjectGroups = PermitObjectPermissions.GroupBy(e => new
            {
                e.GroupId,
                e.PermitObjectId
            }).Select(e => new PermitObjectPermissionModel()
            {
                Id = Guid.NewGuid(),
                Deleted = false,
                PermitObjectId = e.Key.PermitObjectId,
                GroupId = e.Key.GroupId,
                PermissionIds = e.Select(s => s.PermissionId).ToList()
            }).ToList();
        }

        public void ToModel()
        {
            PermitObjectPermissions.Clear();
            foreach (var group in PermitObjectGroups)
            {
                foreach (var permission in group.PermissionIds)
                {
                    PermitObjectPermissions.Add(new PermitObjectPermissionModel()
                    {
                        Id = Guid.NewGuid(),
                        Deleted =false,
                        PermissionId = permission,
                        GroupId = Id,
                        PermitObjectId = group.PermitObjectId,
                    });
                }
            }
        }
    }
}

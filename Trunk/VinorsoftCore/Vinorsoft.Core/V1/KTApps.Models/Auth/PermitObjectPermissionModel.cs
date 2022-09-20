using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Models
{
    public class PermitObjectPermissionModel : KTAppDomainModel
    {
        public PermitObjectPermissionModel()
        {
            PermissionIds = new List<Guid>();
        }
        [Required]
        public Guid PermitObjectId { set; get; }
        [Required]
        public Guid PermissionId { set; get; }
        public Guid? GroupId { set; get; }
        public Guid? UserId { set; get; }

        public PermitObjectModel PermitObjects { set; get; }
        public UserGroupModel UserGroups { set; get; }
        public UserModel Users { set; get; }
        public PermissionModel Permissions { set; get; }

        public IList<Guid> PermissionIds { set; get; }
    }
}

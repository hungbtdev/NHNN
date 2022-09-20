using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.AuthService.Entities
{
    public class PermitObjectPermissions : KTAppDomain
    {
        [ForeignKey("PermitObjects")]
        [Required]
        public Guid PermitObjectId { set; get; }
        [ForeignKey("Permissions")]
        [Required]
        public Guid PermissionId { set; get; }
        [ForeignKey("UserGroups")]
        public Guid? GroupId { set; get; }
        [ForeignKey("Users")]
        public Guid? UserId { set; get; }

        public PermitObjects PermitObjects { set; get; }
        public UserGroups UserGroups { set; get; }
        public Users Users { set; get; }
        public Permissions Permissions { set; get; }

    }
}

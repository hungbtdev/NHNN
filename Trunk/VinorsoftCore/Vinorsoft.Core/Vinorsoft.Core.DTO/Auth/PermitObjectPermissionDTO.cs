using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class PermitObjectPermissionDTO : DomainObjectDTO
    {
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObjectPermission_PermitObject), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public Guid PermitObjectId { set; get; }
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObjectPermission_Permission), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public Guid PermissionId { set; get; }
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObjectPermission_Group), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public Guid? GroupId { set; get; }
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.PermitObjectPermission_User), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public Guid? UserId { set; get; }

        public PermitObjectDTO PermitObjects { set; get; }
        public UserGroupDTO UserGroups { set; get; }
        public UserDTO Users { set; get; }
        public PermissionDTO Permissions { set; get; }

    }
}

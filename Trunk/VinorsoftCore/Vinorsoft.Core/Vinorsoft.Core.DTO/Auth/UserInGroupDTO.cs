using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class UserInGroupDTO : DomainObjectDTO
    {
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.UserInGroup_User), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public Guid UserId { set; get; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.UserInGroup_Group), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public Guid GroupId { set; get; }

        public UserDTO Users { set; get; }
        public UserGroupDTO UserGroups { set; get; }
    }
}

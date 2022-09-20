using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class UserDTO : DomainObjectDTO
    {
        public UserDTO()
        {
            UserInGroups = new HashSet<UserInGroupDTO>();
            UserGroupIds = new List<Guid>();
        }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_Username), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 128, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [RegularExpression("^[a-z0-9_-]{3,128}$", ErrorMessageResourceName = nameof(Resources.DataType_Invalid), ErrorMessageResourceType = typeof(Resources))]
        public string Username { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_Password), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 4000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_Locked), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public bool Locked { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_FailedCount), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public int FailedCount { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_FirstName), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 1000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_LastName), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 1000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string LastName { get; set; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_Phone), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 20, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Phone { get; set; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_Email), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 100, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_LockedEnd), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public DateTime? LockedEnd { get; set; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_UserStatus), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public Guid? StatusId { set; get; }
        public UserStatusDTO UserStatus { set; get; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.UserInGroup_Group), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public IList<Guid> UserGroupIds { get; set; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.UserInGroup_Group), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public IList<Guid> DisplayUserGroupIds
        {
            get
            {
                return UserInGroups.Select(e => e.GroupId).ToList();
            }
        }

        public Guid? ProfileId { set; get; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public ICollection<UserInGroupDTO> UserInGroups { get; set; }
    }
}

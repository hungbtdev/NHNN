using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class UserProfileDTO
    {

        public Guid Id { set; get; }

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
        public string Phone { get; set; }

        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_Email), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 128, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class ChangePasswordDTO
    {
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.ChangePassword_Password), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 4000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.ChangePassword_ConfirmPassword), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 4000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [Compare(nameof(NewPassword), ErrorMessageResourceType = typeof(Vinorsoft.Core.Resx.AuthResource), ErrorMessageResourceName = nameof(Vinorsoft.Core.Resx.AuthResource.ChangePassword_ConfirmPassword_Compare))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { set; get; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.ChangePassword_NewPassword), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 4000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [DataType(DataType.Password)]
        public string NewPassword { set; get; }
    }
}

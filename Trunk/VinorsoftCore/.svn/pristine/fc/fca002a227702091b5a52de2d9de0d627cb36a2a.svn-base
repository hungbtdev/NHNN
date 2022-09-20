using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Core.DTO
{
    public class ResetPasswordDTO
    {
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Resources.DomainObject_Id), ResourceType = typeof(Resources))]
        public Guid Id { set; get; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.User_NewPassword), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 4000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.NewUser_ConfirmPassword), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 4000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [Compare(nameof(NewPassword), ErrorMessageResourceType = typeof(Vinorsoft.Core.Resx.AuthResource), ErrorMessageResourceName = nameof(Vinorsoft.Core.Resx.AuthResource.ChangePassword_ConfirmPassword_Compare))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public void ToValue()
        {
            NewPassword = SecurityUtils.HashSHA1(NewPassword);
            ConfirmPassword = SecurityUtils.HashSHA1(ConfirmPassword);
        }
    }
}

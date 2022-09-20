using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vinorsoft.Core.Resx;
using Vinorsoft.Core.Utils;

namespace Vinorsoft.Core.DTO
{
    public class NewUserDTO : UserDTO
    {
        [Required(ErrorMessageResourceName = nameof(Resources.Required_Message), ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = nameof(Vinorsoft.Core.Resx.AuthResource.NewUser_ConfirmPassword), ResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        [StringLength(maximumLength: 4000, MinimumLength = 1, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        [Compare("Password", ErrorMessageResourceName = nameof(Vinorsoft.Core.Resx.AuthResource.ConfirmPassword_CompareMessage), ErrorMessageResourceType = typeof(Vinorsoft.Core.Resx.AuthResource))]
        public string ConfirmPassword { get; set; }

        public void ToValue()
        {
            if (UserGroupIds.Count > 0)
            {
                UserInGroups = UserGroupIds.Select(e => new UserInGroupDTO()
                {
                    Created = DateTime.Now,
                    Id = Guid.NewGuid(),
                    CreatedBy = CreatedBy,
                    GroupId = e,
                    Updated = DateTime.Now,
                    UserId = Id
                }).ToList();
            }
            Password = SecurityUtils.HashSHA1(Password);
            ConfirmPassword = SecurityUtils.HashSHA1(ConfirmPassword);
        }
    }
}

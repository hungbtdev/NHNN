using KTApps.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KTApps.Models
{
    public class UserModel : KTAppDomainModel
    {
        public UserModel()
        {
            UserDepartments = new List<UserDepartmentModel>();
            UserInGroups = new List<UserInGroupModel>();
        }

        [Required]
        public new Guid Id { get; set; }
        [MaxLength(128, ErrorMessage = "Tên đăng nhập tối đa 128 ký tự")]
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc nhập")]
        public string Username { get; set; }
        [MaxLength(128, ErrorMessage = "Mật khẩu tối đa 128 ký tự")]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc nhập")]
        public string Password { get; set; }
        public bool Locked { get; set; }
        public int FailedCount { get; set; }

        [MaxLength(1000)]
        public string FirstName { get; set; }
        [MaxLength(1000)]
        public string LastName { get; set; }
        [MaxLength(1000)]
        public string Phone { get; set; }
        [MaxLength(1000)]
        public string Email { get; set; }
        public bool IsResetPassword { get; set; }
        public DateTime? LockedEnd { get; set; }

        public Guid? StatusId { set; get; }
        public UserStatusModel UserStatus { set; get; }
        public IList<UserDepartmentModel> UserDepartments { get; set; }
        public IList<UserInGroupModel> UserInGroups { get; set; }
        public IList<string> UserGroupIds { get; set; }
    }
}

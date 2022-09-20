using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KTApps.Models
{
    public class ChangePasswordModel
    {
        public Guid UserId { set; get; }
        [MaxLength(128, ErrorMessage = "Mật khẩu tối đa 128 ký tự")]
        //[Required(ErrorMessage = "Mật khẩu là bắt buộc nhập")]
        public string UserName { set; get; }
        [MaxLength(128, ErrorMessage = "Mật khẩu tối đa 128 ký tự")]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc nhập")]
        public string Password { set; get; }

        [MaxLength(128, ErrorMessage = "Mật khẩu tối đa 128 ký tự")]
        [Required(ErrorMessage = "Mật khẩu mới là bắt buộc nhập")]
        public string NewPassword { set; get; }

        [MaxLength(128, ErrorMessage = "Mật khẩu tối đa 128 ký tự")]
        [Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc nhập")]
        public string ConfirmPassword { get; set; }
    }
}

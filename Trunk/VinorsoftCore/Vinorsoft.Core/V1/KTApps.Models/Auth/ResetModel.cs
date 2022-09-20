using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KTApps.Models
{
    public class ResetPasswordModel
    {
        public Guid UserId { set; get; }

        [MaxLength(128, ErrorMessage = "Mật khẩu tối đa 128 ký tự")]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc nhập")]
        public string Password { set; get; }

        [Compare("Password", ErrorMessage ="Xác nhận mật khẩu không đúng")]
        [Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc nhập")]
        [MaxLength(128, ErrorMessage = "Mật khẩu tối đa 128 ký tự")]
        public string ConfirmPassword { set; get; }
    }
}

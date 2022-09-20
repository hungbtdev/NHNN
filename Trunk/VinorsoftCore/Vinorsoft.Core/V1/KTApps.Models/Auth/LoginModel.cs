using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc nhập")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Mật khẩu là bắt buộc nhập")]
        public string Password { set; get; }
        public Guid? DepartmentId { set; get; }
        [MaxLength(4)]
        public string CaptchaCode { set; get; }
        public Guid? SessionId { set; get; }
        
        public string ConfirmCode { set; get; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Models
{
    public class ForgotPwdModel
    {
        [Required]
        [MaxLength(128)]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { set; get; }
        [Required]
        [MaxLength(20)]
        public string Phone { set; get; }
        [Required]
        [MaxLength(6)]
        public string ConfirmCode { set; get; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Models
{
    public class RegisterModel
    {
        public RegisterModel()
        {
        }

        [MaxLength(128)]
        [Required]
        public string UserName { set; get; }

        [MaxLength]
        [Required]
        public string Password { set; get; }

        [Compare("Password")]
        [Required]
        [MaxLength(128)]
        public string ConfirmPassword { set; get; }

        [Required]
        [MaxLength(128)]
        public string Phone { set; get; }
        [Required]
        [MaxLength(255)]
        public string FirstName { set; get; }
        [MaxLength(255)]
        [Required]
        public string LastName { set; get; }

        [MaxLength(255)]
        public string Email { set; get; }
    }
}

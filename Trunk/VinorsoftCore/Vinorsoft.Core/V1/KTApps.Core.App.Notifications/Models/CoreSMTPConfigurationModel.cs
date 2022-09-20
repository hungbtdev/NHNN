using KTApps.Models;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Notifications.Models
{
    public class CoreSMTPConfigurationModel : KTAppDomainModel
    {
        [MaxLength(1000)]
        [Required]
        public string SmtpServer { set; get; }
        [Required]
        public int Port { set; get; }
        [Required]
        public bool EnableSsl { set; get; }
        [Required]
        [MaxLength(1000)]
        public string DisplayName { set; get; }
        [Required]
        [MaxLength(1000)]
        public string UserName { set; get; }
        [Required]
        [MaxLength(1000)]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
    }
}

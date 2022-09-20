using KTApps.Domain;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.NotificationService.Entities
{
    public class CoreSMTPConfigurations : KTAppDomain
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
        public string Password { set; get; }

        [Required]
        [MaxLength(1000)]
        public string Email { set; get; }
    }
}

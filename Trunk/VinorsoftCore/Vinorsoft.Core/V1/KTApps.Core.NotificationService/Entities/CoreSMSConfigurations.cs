using KTApps.Domain;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.NotificationService.Entities
{
    public class CoreSMSConfigurations : KTAppDomain
    {
        [Required]
        [MaxLength(255)]
        public string BrandName { set; get; }
        [Required]
        [MaxLength(255)]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        [MaxLength(1000)]
        public string Host { set; get; }
        [Required]
        public int Port { set; get; }

        [MaxLength(1000)]
        public string Scheme { set; get; }
        [MaxLength(1000)]
        public string Path { set; get; }
    }
}

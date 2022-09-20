using KTApps.Domain;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.NotificationService.Entities
{
    public class CoreFCMDeviceTokens : KTAppDomain
    {
        [Required]
        public string FCMToken { set; get; }

        [Required]
        [MaxLength(100)]
        public string RefId { set; get; }
        public string Model { set; get; }
    }
}

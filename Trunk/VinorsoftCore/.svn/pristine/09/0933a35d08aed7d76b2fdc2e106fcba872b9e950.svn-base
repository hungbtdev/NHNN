using KTApps.Models;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Notifications.Models
{
    public class CoreFCMDeviceTokenModel : KTAppDomainModel
    {
        [Required]
        public string FCMToken { set; get; }

        [Required]
        [MaxLength(100)]
        public string RefId { set; get; }
        public string Model { set; get; }
    }
}

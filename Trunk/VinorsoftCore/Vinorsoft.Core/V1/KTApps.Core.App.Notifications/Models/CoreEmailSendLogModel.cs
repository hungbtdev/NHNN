using KTApps.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Notifications.Models
{
    public class CoreEmailSendLogModel : KTAppDomainModel
    {
        [Required]
        public Guid PendingId { set; get; }
        [Required]
        public Guid StatusId { set; get; }
        [Required]
        [MaxLength(1000)]
        public string EmailFrom { set; get; }
        [Required]
        [MaxLength(1000)]
        public string EmailTo { set; get; }
        public CoreNotificationStatusModel CoreNotificationStatus { set; get; }
        public CoreEmailPendingModel CoreEmailPendings { set; get; }
    }
}

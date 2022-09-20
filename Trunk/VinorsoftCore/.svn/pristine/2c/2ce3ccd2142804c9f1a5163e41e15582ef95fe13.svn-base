using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.Core.NotificationService.Entities
{
    public class CoreEmailSendLogs : KTAppDomain
    {
        [ForeignKey("CoreEmailPendings")]
        [Required]
        public Guid PendingId { set; get; }
        [ForeignKey("CoreNotificationStatus")]
        [Required]
        public Guid StatusId { set; get; }
        [Required]
        [MaxLength(1000)]
        public string EmailFrom { set; get; }
        [Required]
        [MaxLength(1000)]
        public string EmailTo { set; get; }
        public CoreNotificationStatus CoreNotificationStatus { set; get; }
        public CoreEmailPendings CoreEmailPendings { set; get; }
    }
}

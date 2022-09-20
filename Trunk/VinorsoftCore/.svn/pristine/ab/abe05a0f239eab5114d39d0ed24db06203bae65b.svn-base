using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.Core.NotificationService.Entities
{
    public class CoreSMSPendings : KTAppDomain
    {
        [MaxLength(1000)]
        [Required]
        public string Subject { set; get; }
        [MaxLength(1000)]
        [Required]
        public string Phone { set; get; }
        [Required]
        [MaxLength(1000)]
        public string Body { set; get; }

        [Required]
        [ForeignKey("CoreNotificationStatus")]
        public Guid StatusId { set; get; }
        public CoreNotificationStatus CoreNotificationStatus { set; get; }
    }
}

using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.Core.NotificationService.Entities
{
    public class CoreEmailPendings : KTAppDomain
    {
        [MaxLength(1000)]
        [Required]
        public string Subject { set; get; }
        [MaxLength(1000)]
        [Required]
        public string EmailTo { set; get; }
        [MaxLength(1000)]
        [Required]
        public string CC { set; get; }
        [MaxLength(1000)]
        [Required]
        public string BCC { set; get; }

        [Required]
        public string Body { set; get; }
        [Required]
        public bool IsBodyHtml { set; get; }
        public int? MailPriority { set; get; }
        [ForeignKey("CoreNotificationStatus")]
        public Guid StatusId { set; get; }
        public CoreNotificationStatus CoreNotificationStatus { set; get; }
    }
}

using KTApps.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Notifications.Models
{
    public class CoreEmailPendingModel : KTAppDomainModel
    {
        [MaxLength(1000)]
        public string Subject { set; get; }
        [MaxLength(1000)]
        public string EmailTo { set; get; }
        [MaxLength(1000)]
        public string CC { set; get; }
        [MaxLength(1000)]
        public string BCC { set; get; }
        public string Body { set; get; }
        public bool IsBodyHtml { set; get; }
        public int? MailPriority { set; get; }
        public Guid StatusId { set; get; }
        public CoreNotificationStatusModel CoreNotificationStatus { set; get; }
    }
}

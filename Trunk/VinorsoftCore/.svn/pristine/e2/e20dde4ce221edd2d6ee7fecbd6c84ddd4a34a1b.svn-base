using KTApps.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace KTApps.Core.App.Notifications.Models
{
    public class CoreNotificationTemplateModel : KTAppDomainModel
    {
        [Required]
        [MaxLength(255)]
        public string Code { set; get; }
        [Required]
        [MaxLength(255)]
        public string Name { set; get; }
        [Required]
        [MaxLength(255)]
        public string Subject { set; get; }
        [Required]
        [MaxLength(255)]
        public string Body { set; get; }
        public Guid NotificationTypeId { set; get; }

        public bool AllowHtml { set; get; }

        public CoreNotificationTypeModel CoreNotificationTypes { set; get; }
    }
}

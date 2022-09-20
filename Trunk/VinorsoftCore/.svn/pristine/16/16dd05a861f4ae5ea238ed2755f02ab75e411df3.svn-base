using KTApps.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTApps.Core.NotificationService.Entities
{
    public class CoreNotificationTemplates : KTAppDomain
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
        [Required]
        public bool AllowHtml { set; get; }
        [ForeignKey("CoreNotificationTypes")]
        public Guid NotificationTypeId { set; get; }
        public CoreNotificationTypes CoreNotificationTypes { set; get; }
    }
}

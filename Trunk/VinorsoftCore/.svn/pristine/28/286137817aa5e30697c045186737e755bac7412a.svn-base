using System;
using System.ComponentModel.DataAnnotations;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core.DTO
{
    public class DeviceTokenDTO : DomainObjectDTO
    {
        [Display(Name = nameof(Resources.AppName), ResourceType = typeof(Resources))]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessageResourceName = nameof(Resources.Length_Message), ErrorMessageResourceType = typeof(Resources))]
        public string AppName { set; get; }

        [Display(Name = nameof(NotificationResource.IsDevice), ResourceType = typeof(NotificationResource))]
        public bool IsDevice { set; get; }

        [Display(Name = nameof(NotificationResource.Brand), ResourceType = typeof(NotificationResource))]
        public string Brand { set; get; }
        
        [Display(Name = nameof(NotificationResource.Manufacturer), ResourceType = typeof(NotificationResource))]
        public string Manufacturer { set; get; }
        
        [Display(Name = nameof(NotificationResource.ModelName), ResourceType = typeof(NotificationResource))]
        public string ModelName { set; get; }
        
        [Display(Name = nameof(NotificationResource.OsName), ResourceType = typeof(NotificationResource))]
        public string OsName { set; get; }
        
        [Display(Name = nameof(NotificationResource.OsVersion), ResourceType = typeof(NotificationResource))]
        public string OsVersion { set; get; }
        
        [Display(Name = nameof(NotificationResource.DeviceName), ResourceType = typeof(NotificationResource))]
        public string DeviceName { set; get; }

        [Display(Name = nameof(NotificationResource.RefId), ResourceType = typeof(NotificationResource))]
        public Guid? RefId { set; get; }

        [Display(Name = nameof(NotificationResource.ExpoPushToken), ResourceType = typeof(NotificationResource))]
        public string ExpoPushToken { set; get; }
        
        [Display(Name = nameof(NotificationResource.FCMToken), ResourceType = typeof(NotificationResource))]
        public string FCMToken { set; get; }
    }
}

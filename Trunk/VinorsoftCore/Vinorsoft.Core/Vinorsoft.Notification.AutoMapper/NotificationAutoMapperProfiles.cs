using AutoMapper;
using Vinorsoft.Core.DTO;
using Vinorsoft.Core.Entities;

namespace Vinorsoft.Notification.AutoMapper
{
    public class NotificationAutoMapperProfiles : Profile
    {
        public NotificationAutoMapperProfiles()
        {
            CreateMap<EmailTemplates,EmailTemplateDTO>().ReverseMap().MaxDepth(1);
            CreateMap<FCMTemplates, FCMTemplateDTO>().ReverseMap().MaxDepth(1);
            CreateMap<SMSTemplates,SMSTemplateDTO>().ReverseMap().MaxDepth(1);
            CreateMap<DeviceTokens, DeviceTokenDTO>().ReverseMap().MaxDepth(1);
            CreateMap<NotificationMessages, NotificationMessageDTO>().ReverseMap().MaxDepth(1);
        }
    }
}

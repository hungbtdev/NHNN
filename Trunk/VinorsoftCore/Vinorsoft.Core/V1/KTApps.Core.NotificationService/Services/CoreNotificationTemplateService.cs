using AutoMapper;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Core.Services;

namespace KTApps.Core.NotificationService
{
    public class CoreNotificationTemplateService : DomainService<CoreNotificationTemplates>, ICoreNotificationTemplateService
    {
        public CoreNotificationTemplateService(ICoreNotificationUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}

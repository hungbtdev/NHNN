using AutoMapper;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Core.Services;

namespace KTApps.Core.NotificationService
{
    public class CoreNotificationStatusService : CatalogueService<CoreNotificationStatus>, ICoreNotificationStatusService
    {
        public CoreNotificationStatusService(ICoreNotificationUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}

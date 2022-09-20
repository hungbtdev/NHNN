using AutoMapper;
using KTApps.Core.NotificationService.Entities;
using KTApps.Core.NotificationService.Interface;
using KTApps.Core.Services;

namespace KTApps.Core.NotificationService
{
    public class CoreSMSConfigurationService : DomainService<CoreSMSConfigurations>, ICoreSMSConfigurationService
    {
        public CoreSMSConfigurationService(ICoreNotificationUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
    }
}

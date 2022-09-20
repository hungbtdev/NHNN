using AutoMapper;
using KTApps.Core.LoggingService.Entities;
using KTApps.Core.LoggingService.Interface;
using KTApps.Core.Services;

namespace KTApps.Core.LoggingService
{
    public class ActivityLoggingService : DomainService<CoreApiLogItems>, IActivityLoggingService
    {
        public ActivityLoggingService(ILoggingUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}

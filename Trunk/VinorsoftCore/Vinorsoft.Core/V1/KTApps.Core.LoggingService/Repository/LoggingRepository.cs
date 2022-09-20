using KTApps.Core.LoggingService.Interface;
using KTApps.Core.EF;
using KTApps.Domain;

namespace KTApps.Core.LoggingService.Repository
{
    public class LoggingRepository<T> : DomainRepository<T>, ILoggingRepository<T> where T : KTAppDomain
    {
        public LoggingRepository(ILoggingDbContext context) : base(context)
        {
        }
    }
}

using KTApps.Core.EF;
using KTApps.Core.NotificationService.Interface;
using KTApps.Domain;

namespace KTApps.Core.NotificationService.Repository
{
    public class NotificationRepository<T> : DomainRepository<T>, INotificationRepository<T> where T : KTAppDomain
    {
        public NotificationRepository(ICoreNotificationDbContext context) : base(context)
        {
        }
    }
}

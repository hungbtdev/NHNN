using KTApps.Core.EF;
using KTApps.Core.NotificationService.Interface;
using KTApps.Core.NotificationService.Repository;

namespace KTApps.Core.NotificationService
{
    public class CoreNotificationUnitOfWork : UnitOfWork, ICoreNotificationUnitOfWork
    {
        readonly ICoreNotificationDbContext coreNotificationDbContext;
        public CoreNotificationUnitOfWork(ICoreNotificationDbContext coreNotificationDbContext) : base(coreNotificationDbContext)
        {
            this.coreNotificationDbContext = coreNotificationDbContext;
        }
        public override IDomainRepository<T> Repository<T>()
        {
            return new NotificationRepository<T>(coreNotificationDbContext);
        }
    }
}

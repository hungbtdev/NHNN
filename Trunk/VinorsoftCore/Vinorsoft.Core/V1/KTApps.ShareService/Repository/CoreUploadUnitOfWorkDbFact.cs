using KTApps.Core.EF;
using KTApps.ShareService.Factory;
using KTApps.ShareService.Interface;
using KTApps.ShareService.Repository;

namespace KTApps.ShareService
{
    public class CoreUploadUnitOfWorkDbFact : UnitOfWork, ICoreUploadUnitOfWork
    {
        public CoreUploadUnitOfWorkDbFact(ICoreUploadDbFactory coreUploadDbFactory) : base(coreUploadDbFactory)
        {
        }

        public override IDomainRepository<T> Repository<T>()
        {
            return new CoreUploadRepository<T>((ICoreUploadDbContext)context);
        }
    }
}

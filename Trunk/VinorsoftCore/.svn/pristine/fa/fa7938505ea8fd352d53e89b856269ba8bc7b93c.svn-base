using KTApps.Core.EF;
using KTApps.Core.Factory;
using KTApps.Domain;
using KTApps.ShareService.Interface;

namespace KTApps.ShareService.Repository
{
    public class CoreUploadRepository<T> : DomainRepository<T>, ICoreUploadRepository<T> where T : KTAppDomain
    {
        public CoreUploadRepository(ICoreDbContext context) : base(context)
        {
        }

        public CoreUploadRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}

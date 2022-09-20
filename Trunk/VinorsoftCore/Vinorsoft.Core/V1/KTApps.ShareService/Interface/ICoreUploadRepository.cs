using KTApps.Core.EF;
using KTApps.Domain;

namespace KTApps.ShareService.Interface
{
    public interface ICoreUploadRepository<T> : IDomainRepository<T> where T : KTAppDomain
    {
    }
}

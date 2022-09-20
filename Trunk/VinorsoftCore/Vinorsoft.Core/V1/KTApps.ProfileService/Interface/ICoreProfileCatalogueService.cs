using KTApps.Core.Interface;
using KTApps.Domain;

namespace KTApps.ProfileService.Interface
{
    public interface ICoreProfileCatalogueService<T> : ICatalogueService<T> where T : KTAppDomainCatalogue
    {
    }
}

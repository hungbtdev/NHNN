using KTApps.Domain;

namespace KTApps.Core.EF
{
    public interface ICatalogueRepository<T> : IDomainRepository<T> where T : KTAppDomainCatalogue
    {
        T GetByCode(string code);
    }
}

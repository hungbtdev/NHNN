using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Interface
{
    public interface ICoreCatalogueService<E> : ICoreService<E> where E : VinorsoftCatalogueDomain
    {
        E GetByCode(string code);
    }
}

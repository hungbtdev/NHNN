using System;
using System.Linq;
using Vinorsoft.Core.Domain;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core
{
    public class CoreCatalogueService<E> : CoreService<E>, ICoreCatalogueService<E> where E : VinorsoftCatalogueDomain
    {
        public CoreCatalogueService(ICoreDbContext coreDbContext) : base(coreDbContext)
        {
        }

        public E GetByCode(string code)
        {
            return Queryable.FirstOrDefault(e => e.Code == code);
        }

        public override int Insert(E entity)
        {
            if (Any(e => e.Code == entity.Code && e.Id != entity.Id))
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, entity.Code));
            }
            return base.Insert(entity);
        }

        public override int Update(E entity)
        {
            if (Any(e => e.Code == entity.Code && e.Id != entity.Id))
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, entity.Code));
            }
            return base.Update(entity);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vinorsoft.Core.Interface;
using Vinorsoft.Core.Domain;
using Vinorsoft.Core.Resx;

namespace Vinorsoft.Core
{
    public abstract class CoreService<E> : ICoreService<E> where E : VinorsoftDomain
    {
        protected ICoreDbContext coreDbContext;
        public CoreService(ICoreDbContext coreDbContext)
        {
            this.coreDbContext = coreDbContext;
        }

        public IQueryable<E> Queryable
        {
            get
            {
                return coreDbContext.Set<E>().Where(e => !e.Deleted);
            }
        }

        public virtual int Insert(E entity)
        {
            var exists = Any(entity.Id);
            if (exists)
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, entity.Id));
            }
            coreDbContext.Set<E>().Add(entity);
            return coreDbContext.SaveChanges();
        }

        public virtual async Task<int> InsertAsync(E entity)
        {
            var exists = Any(entity.Id);
            if (exists)
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_EXISTED_ITEM, entity.Id));
            }
            await coreDbContext.Set<E>().AddAsync(entity);
            return await coreDbContext.SaveChangesAsync();
        }

        public virtual int Update(E entity)
        {
            var exists = GetById(entity.Id);
            if (exists == null)
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, entity.Id));
            }
            coreDbContext.Set<E>().Update(entity);
            return coreDbContext.SaveChanges();
        }

        public virtual int Delete(Guid id)
        {
            var exists = GetById(id);
            if (exists == null)
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, id));
            }
            exists.Deleted = true;
            coreDbContext.Set<E>().Update(exists);
            return coreDbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            var exists = await GetByIdAsync(id);
            if (exists != null)
            {
                throw new Exception(string.Format(CoreErrorResource.ERROR_NOT_FOUND, id));
            }
            exists.Deleted = true;
            coreDbContext.Set<E>().Update(exists);
            return await coreDbContext.SaveChangesAsync();
        }

        public virtual bool Any(Guid id)
        {
            return Any(e => e.Id == id);
        }

        public virtual bool Any(Expression<Func<E, bool>> expression)
        {
            return Queryable.AsNoTracking().Any(expression);
        }

        public virtual E GetById(Guid id)
        {
            return Queryable.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public virtual async Task<E> GetByIdAsync(Guid id)
        {
            return await Queryable.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual IEnumerable<E> Get(Expression<Func<E, bool>> expression)
        {
            return Queryable.AsNoTracking().Where(expression);
        }
    }
}

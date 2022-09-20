using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vinorsoft.Core.Domain;

namespace Vinorsoft.Core.Interface
{
    public interface ICoreService<E> where E : VinorsoftDomain
    {
        IQueryable<E> Queryable { get; }
        int Insert(E entity);
        Task<int> InsertAsync(E entity);
        int Update(E entity);
        int Delete(Guid id);
        Task<int> DeleteAsync(Guid id);
        bool Any(Guid id);
        bool Any(Expression<Func<E, bool>> expression);
        E GetById(Guid id);
        Task<E> GetByIdAsync(Guid id);
        IEnumerable<E> Get(Expression<Func<E, bool>> expression);
    }
}

using AutoMapper;
using KTApps.Core.Paging;
using KTApps.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KTApps.Core
{
    public interface IDomainService<E> where E : KTAppDomain
    {
        bool Exists(Expression<Func<E, bool>> expression);
        bool Save(E item);
        bool Save(E item, params string[] properties);
        bool Save(IList<E> items);
        bool Delete(Guid id);
        IList<E> GetAll();
        E GetById(Guid id);
        Task<E> GetByIdAsync(Guid id);
        E GetById(Guid id, Expression<Func<E, E>> select);
        E GetById(Guid id, IConfigurationProvider mapperConfiguration);
        Task<E> GetByIdAsync(Guid id, IConfigurationProvider mapperConfiguration);

        IList<E> GetAll(Expression<Func<E, E>> select);
        IList<E> Get(Expression<Func<E, bool>> expression, Expression<Func<E, E>> select);
        IList<E> Get(Expression<Func<E, bool>>[] expression, Expression<Func<E, E>> select);
        IList<E> Get(Expression<Func<E, bool>> expression);

        IList<E> Get(string expression, Expression<Func<E, E>> select);
        IList<E> Get(string expression, IConfigurationProvider mapperConfiguration);
        PagedList<E> Get(string expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy);
        PagedList<E> Get(string expression, int pageIndex, int pageSize, string orderBy);
        PagedList<E> Get(string expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration);

        IList<E> Get(string expression, Expression<Func<E, E>> select, params Expression<Func<E, bool>>[] linqExp);
        IList<E> Get(string expression, IConfigurationProvider mapperConfiguration, params Expression<Func<E, bool>>[] linqExp);
        PagedList<E> Get(string expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy, params Expression<Func<E, bool>>[] linqExp);
        PagedList<E> Get(string expression, int pageIndex, int pageSize, string orderBy, params Expression<Func<E, bool>>[] linqExp);
        PagedList<E> Get(string expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration, params Expression<Func<E, bool>>[] linqExp);


        IList<E> Get(Expression<Func<E, bool>>[] expression);
        IList<E> Get(Expression<Func<E, bool>> expression, IConfigurationProvider mapperConfiguration);
        IList<E> Get(Expression<Func<E, bool>>[] expression, IConfigurationProvider mapperConfiguration);
        PagedList<E> Get(Expression<Func<E, bool>> expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy);
        PagedList<E> Get(Expression<Func<E, bool>>[] expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy);
        PagedList<E> Get(Expression<Func<E, bool>> expression, int pageIndex, int pageSize, string orderBy);
        PagedList<E> Get(Expression<Func<E, bool>>[] expression, int pageIndex, int pageSize, string orderBy);
        PagedList<E> Get(Expression<Func<E, bool>> expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration);
        PagedList<E> Get(Expression<Func<E, bool>>[] expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration);

        Task<bool> SaveAsync(E item);
        Task<bool> SaveAsync(IList<E> items);
        Task<bool> DeleteAsync(Guid id);
        Task<IList<E>> GetAllAsync();
        Task<E> GetByIdAsync(Guid id, Expression<Func<E, E>> select);
        Task<IList<E>> GetAllAsync(Expression<Func<E, E>> select);
        Task<IList<E>> GetAsync(Expression<Func<E, bool>> expression, Expression<Func<E, E>> select);
        Task<IList<E>> GetAsync(Expression<Func<E, bool>>[] expression, Expression<Func<E, E>> select);
        Task<IList<E>> GetAsync(Expression<Func<E, bool>> expression);
        Task<IList<E>> GetAsync(Expression<Func<E, bool>>[] expression);
        Task<IList<E>> GetAsync(Expression<Func<E, bool>> expression, bool useProjectTo);
        Task<IList<E>> GetAsync(Expression<Func<E, bool>>[] expression, bool useProjectTo);
        Task<PagedList<E>> GetAsync(Expression<Func<E, bool>> expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy);
        Task<PagedList<E>> GetAsync(Expression<Func<E, bool>>[] expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy);
        Task<PagedList<E>> GetAsync(Expression<Func<E, bool>> expression, int pageIndex, int pageSize, string orderBy);
        Task<PagedList<E>> GetAsync(Expression<Func<E, bool>>[] expression, int pageIndex, int pageSize, string orderBy);
        Task<PagedList<E>> GetAsync(Expression<Func<E, bool>> expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration);
        Task<PagedList<E>> GetAsync(Expression<Func<E, bool>>[] expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration);
    }
}

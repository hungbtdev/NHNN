using AutoMapper;
using AutoMapper.QueryableExtensions;
using KTApps.Core.EF;
using KTApps.Core.Paging;
using KTApps.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KTApps.Core.Services
{
    public abstract class DomainService<E> : IDomainService<E> where E : KTAppDomain, new()
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;
        protected IQueryable<E> Queryable
        {
            get
            {
                return unitOfWork.Repository<E>().GetQueryable().AsNoTracking();
            }
        }
        public DomainService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public virtual void LoadReferences(IList<E> items)
        {
        }

        public virtual bool Save(E item, params string[] properties)
        {
            var exists = Queryable
            .AsNoTracking()
            .Where(e =>
            e.Id == item.Id
            && !e.Deleted)
            .FirstOrDefault();
            if (exists != null)
            {
                if (item.Deleted)
                {
                    Delete(item.Id);
                }
                else
                {
                    exists = mapper.Map<E>(item);
                    unitOfWork.Repository<E>().Update(exists, properties);
                }
            }
            else
            {
                unitOfWork.Repository<E>().Create(item);
            }
            unitOfWork.Save();
            return true;
        }

        public virtual bool Save(E item)
        {
            return Save(new List<E> { item });
        }
        public virtual bool Save(IList<E> items)
        {
            foreach (var item in items)
            {
                var exists = Queryable
                .AsNoTracking()
                .Where(e =>
                e.Id == item.Id
                && !e.Deleted)
                .FirstOrDefault();
                if (exists != null)
                {
                    if (item.Deleted)
                    {
                        Delete(item.Id);
                    }
                    else
                    {
                        exists = mapper.Map<E>(item);
                        unitOfWork.Repository<E>().SetEntityState(exists, EntityState.Modified);
                    }
                }
                else
                {
                    unitOfWork.Repository<E>().Create(item);
                }
            }
            unitOfWork.Save();
            return true;
        }

        public virtual bool Exists(Expression<Func<E, bool>> expression)
        {
            return unitOfWork.Repository<E>().GetQueryable().Where(e => !e.Deleted).Any(expression);
        }

        public virtual bool Delete(Guid id)
        {
            //if (!IsSafeDelete(id))
            //{
            //    throw new Exception(id + " can not delete check relationship before.");
            //}

            var exists = Queryable
                .Where(e => e.Id == id)
                .FirstOrDefault();
            if (exists != null)
            {
                exists.Deleted = true;
                unitOfWork.Repository<E>().Update(exists);
                unitOfWork.Save();
                return true;
            }
            else
            {
                throw new Exception(id + " not exists");
            }
        }

        public virtual IList<E> GetAll()
        {
            return GetAll(null);
        }
        public virtual IList<E> GetAll(Expression<Func<E, E>> select)
        {
            var query = Queryable.Where(e => !e.Deleted);
            if (select != null)
            {
                query = query.Select(select);
            }
            return query.ToList();
        }

        public virtual E GetById(Guid id)
        {
            return GetById(id, (IConfigurationProvider)null);
        }
        public virtual E GetById(Guid id, Expression<Func<E, E>> select)
        {
            var query = Queryable.Where(e => !e.Deleted);
            if (select != null)
            {
                query = query.Select(select);
            }
            return query
                 .AsNoTracking()
                 .Where(e => e.Id == id)
                 .FirstOrDefault();
        }

        public IList<E> Get(Expression<Func<E, bool>> expression)
        {
            return Get(new Expression<Func<E, bool>>[] { expression });
        }

        //
        public IList<E> Get(Expression<Func<E, bool>> expression, Expression<Func<E, E>> select)
        {
            return Get(new Expression<Func<E, bool>>[] { expression }, select);
        }
        public IList<E> Get(Expression<Func<E, bool>> expression, IConfigurationProvider mapperConfiguration)
        {
            if (mapperConfiguration == null)
            {
                return Get(expression);
            }
            else
            {
                return Get(new Expression<Func<E, bool>>[] { expression }, mapperConfiguration);
            }
        }
        public PagedList<E> Get(Expression<Func<E, bool>> expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy)
        {
            var queryable = Queryable.Where(e => !e.Deleted).Where(expression).AsNoTracking();
            if (select != null)
                queryable = queryable.Select(select);
            PagedList<E> pagedList = new PagedList<E>(queryable);
            pagedList.ToPage(pageIndex, pageSize, orderBy);
            return pagedList;
        }
        public PagedList<E> Get(Expression<Func<E, bool>> expression, int pageIndex, int pageSize, string orderBy)
        {
            return Get(expression, null, pageIndex, pageSize, orderBy);
        }
        public PagedList<E> Get(Expression<Func<E, bool>> expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration)
        {
            if (mapperConfiguration == null)
            {
                return Get(expression, pageIndex, pageSize, orderBy);
            }
            else
            {
                var queryable = Queryable.Where(e => !e.Deleted);
                queryable = queryable.AsNoTracking().Where(expression)
                    .ProjectTo<E>(mapperConfiguration);
                PagedList<E> pagedList = new PagedList<E>(queryable);
                pagedList.ToPage(pageIndex, pageSize, orderBy);
                return pagedList;
            }

        }

        // Condition is String
        public IList<E> Get(string expression, Expression<Func<E, E>> select)
        {
            var queryable = Queryable.Where(e => !e.Deleted).Where(expression);
            if (select != null)
                queryable = queryable.Select(select);
            return queryable.ToList();
        }
        public IList<E> Get(string expression, IConfigurationProvider mapperConfiguration)
        {
            var queryable = Queryable.Where(e => !e.Deleted).Where(expression);
            queryable = queryable
                .ProjectTo<E>(mapperConfiguration);
            return queryable.ToList();
        }
        public PagedList<E> Get(string expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy)
        {
            var queryable = Queryable.Where(e => !e.Deleted).Where(expression).AsNoTracking();
            if (select != null)
                queryable = queryable.Select(select);
            PagedList<E> pagedList = new PagedList<E>(queryable);
            pagedList.ToPage(pageIndex, pageSize, orderBy);
            return pagedList;
        }
        public PagedList<E> Get(string expression, int pageIndex, int pageSize, string orderBy)
        {
            return Get(expression, null, pageIndex, pageSize, orderBy);
        }
        public PagedList<E> Get(string expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration)
        {
            if (mapperConfiguration == null)
            {
                return Get(expression, pageIndex, pageSize, orderBy);
            }
            else
            {
                var queryable = Queryable.Where(e => !e.Deleted);
                queryable = queryable.AsNoTracking().Where(expression)
                    .ProjectTo<E>(mapperConfiguration);
                PagedList<E> pagedList = new PagedList<E>(queryable);
                pagedList.ToPage(pageIndex, pageSize, orderBy);
                return pagedList;
            }
        }

        //
        public IList<E> Get(string expression, Expression<Func<E, E>> select, params Expression<Func<E, bool>>[] linqExp)
        {
            var queryable = Queryable.Where(e => !e.Deleted).Where(expression);
            if (linqExp != null)
            {
                foreach (var exp in linqExp)
                {
                    queryable = queryable.Where(exp);
                }
            }
            if (select != null)
                queryable = queryable.Select(select);
            return queryable.ToList();
        }
        public IList<E> Get(string expression, IConfigurationProvider mapperConfiguration, params Expression<Func<E, bool>>[] linqExp)
        {
            var queryable = Queryable.Where(e => !e.Deleted).Where(expression);
            if (linqExp != null)
            {
                foreach (var exp in linqExp)
                {
                    queryable = queryable.Where(exp);
                }
            }
            queryable = queryable
                .ProjectTo<E>(mapperConfiguration);
            return queryable.ToList();
        }
        public PagedList<E> Get(string expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy, params Expression<Func<E, bool>>[] linqExp)
        {
            var queryable = Queryable.Where(e => !e.Deleted).Where(expression);
            if (linqExp != null)
            {
                foreach (var exp in linqExp)
                {
                    queryable = queryable.Where(exp);
                }
            }

            if (select != null)
                queryable = queryable.Select(select);
            PagedList<E> pagedList = new PagedList<E>(queryable);
            pagedList.ToPage(pageIndex, pageSize, orderBy);
            return pagedList;
        }
        public PagedList<E> Get(string expression, int pageIndex, int pageSize, string orderBy, params Expression<Func<E, bool>>[] linqExp)
        {
            return Get(expression, null, pageIndex, pageSize, orderBy, linqExp);
        }
        public PagedList<E> Get(string expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration, params Expression<Func<E, bool>>[] linqExp)
        {
            if (mapperConfiguration == null)
            {
                return Get(expression, pageIndex, pageSize, orderBy, linqExp);
            }
            else
            {
                var queryable = Queryable.Where(e => !e.Deleted);
                if (linqExp != null)
                {
                    foreach (var exp in linqExp)
                    {
                        queryable = queryable.Where(exp);
                    }
                }
                queryable = queryable.AsNoTracking().Where(expression)
                    .ProjectTo<E>(mapperConfiguration);
                PagedList<E> pagedList = new PagedList<E>(queryable);
                pagedList.ToPage(pageIndex, pageSize, orderBy);
                return pagedList;
            }
        }

        public virtual async Task<bool> SaveAsync(E item)
        {
            return await SaveAsync(new List<E> { item });
        }
        public async Task<bool> SaveAsync(IList<E> items)
        {
            foreach (var item in items)
            {
                var exists = await Queryable
                 .AsNoTracking()
                 .Where(e => e.Id == item.Id && !e.Deleted)
                 .FirstOrDefaultAsync();

                if (exists != null)
                {
                    exists = mapper.Map<E>(item);
                    unitOfWork.Repository<E>().Update(exists);
                }
                else
                {
                    await unitOfWork.Repository<E>().CreateAsync(item);
                }
            }
            await unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            //if (!IsSafeDelete(id))
            //{
            //    throw new Exception(id + " can not delete check relationship before.");
            //}
            var exists = Queryable
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
            if (exists != null)
            {
                exists.Deleted = true;
                unitOfWork.Repository<E>().Update(exists);
                await unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                throw new Exception(id + " not exists");
            }
        }

        public async Task<IList<E>> GetAllAsync()
        {
            return await Queryable.AsNoTracking().ToListAsync();
        }

        public async Task<E> GetByIdAsync(Guid id)
        {
            return await Queryable.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task<E> GetByIdAsync(Guid id, Expression<Func<E, E>> select)
        {
            var query = unitOfWork.Repository<E>()
               .GetQueryable()
               .AsNoTracking();
            if (select != null)
            {
                query = query.Select(select);
            }
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IList<E>> GetAllAsync(Expression<Func<E, E>> select)
        {
            return await Queryable
                .Select(select)
                .ToListAsync();

        }

        public async Task<IList<E>> GetAsync(Expression<Func<E, bool>> expression, Expression<Func<E, E>> select)
        {
            return await unitOfWork.Repository<E>()
                 .GetQueryable()
                 .Where(expression)
                 .Select(select)
                 .ToListAsync();
        }

        public async Task<IList<E>> GetAsync(Expression<Func<E, bool>> expression)
        {
            return await unitOfWork.Repository<E>()
                .GetQueryable()
                .Where(expression)
                .ToListAsync();
        }

        public async Task<IList<E>> GetAsync(Expression<Func<E, bool>> expression, bool useProjectTo)
        {
            if (useProjectTo)
                return await unitOfWork.Repository<E>()
                .GetQueryable()
                .ProjectTo<E>(mapper.ConfigurationProvider)
                .Where(expression)
                .ToListAsync();
            return await unitOfWork.Repository<E>()
                .GetQueryable()
                .ProjectTo<E>(mapper.ConfigurationProvider)
                .Where(expression)
                .ToListAsync();
        }

        public async Task<PagedList<E>> GetAsync(Expression<Func<E, bool>> expression, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy)
        {
            return await GetAsync(new Expression<Func<E, bool>>[] { expression }, select, pageIndex, pageSize, orderBy);

        }

        public async Task<PagedList<E>> GetAsync(Expression<Func<E, bool>> expression, int pageIndex, int pageSize, string orderBy)
        {
            return await GetAsync(expression, null, pageIndex, pageSize, orderBy);
        }

        public async Task<PagedList<E>> GetAsync(Expression<Func<E, bool>> expression, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration)
        {
            var queryable = Queryable;
            queryable = queryable.AsNoTracking().Where(expression);
            if (mapperConfiguration != null)
            {
                queryable = queryable.ProjectTo<E>(mapperConfiguration);
            }
            PagedList<E> pagedList = new PagedList<E>(queryable);
            await pagedList.ToPageAsync(pageIndex, pageSize, orderBy);
            return pagedList;
        }

        public E GetById(Guid id, IConfigurationProvider mapperConfiguration)
        {
            var queryable = Queryable.Where(e => !e.Deleted && e.Id == id);
            if (mapperConfiguration != null)
                queryable = queryable.ProjectTo<E>(mapperConfiguration);
            return queryable.AsNoTracking().FirstOrDefault();
        }

        public async Task<E> GetByIdAsync(Guid id, IConfigurationProvider mapperConfiguration)
        {
            var queryable = Queryable.Where(e => !e.Deleted && e.Id == id);
            if (mapperConfiguration != null)
                queryable = queryable.ProjectTo<E>(mapperConfiguration);
            return await queryable.AsNoTracking().FirstOrDefaultAsync();
        }

        public IList<E> Get(Expression<Func<E, bool>>[] expressions, Expression<Func<E, E>> select)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            if (select != null)
                queryable = queryable.Select(select);
            return queryable.ToList();
        }

        public IList<E> Get(Expression<Func<E, bool>>[] expressions)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            return queryable.ToList();
        }

        public IList<E> Get(Expression<Func<E, bool>>[] expressions, IConfigurationProvider mapperConfiguration)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            queryable = queryable
                .ProjectTo<E>(mapperConfiguration);
            return queryable.ToList();
        }

        public PagedList<E> Get(Expression<Func<E, bool>>[] expressions, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }

            if (select != null)
            {
                queryable = queryable.Select(select);
            }
            PagedList<E> pagedList = new PagedList<E>(queryable);
            pagedList.ToPage(pageIndex, pageSize, orderBy);
            return pagedList;
        }

        public PagedList<E> Get(Expression<Func<E, bool>>[] expressions, int pageIndex, int pageSize, string orderBy)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            PagedList<E> pagedList = new PagedList<E>(queryable);
            pagedList.ToPage(pageIndex, pageSize, orderBy);
            return pagedList;
        }

        public PagedList<E> Get(Expression<Func<E, bool>>[] expressions, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            queryable = queryable.ProjectTo<E>(mapper.ConfigurationProvider);
            PagedList<E> pagedList = new PagedList<E>(queryable);
            pagedList.ToPage(pageIndex, pageSize, orderBy);
            return pagedList;
        }

        public async Task<IList<E>> GetAsync(Expression<Func<E, bool>>[] expressions, Expression<Func<E, E>> select)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            if (select != null)
            {
                queryable = queryable.Select(select);
            }
            return await queryable.ToListAsync();
        }

        public async Task<IList<E>> GetAsync(Expression<Func<E, bool>>[] expressions)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }

            return await queryable.ToListAsync();
        }

        public async Task<IList<E>> GetAsync(Expression<Func<E, bool>>[] expressions, bool useProjectTo)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            if (useProjectTo)
            {
                queryable = queryable.ProjectTo<E>(mapper.ConfigurationProvider);
            }
            return await queryable.ToListAsync();
        }

        public async Task<PagedList<E>> GetAsync(Expression<Func<E, bool>>[] expressions, Expression<Func<E, E>> select, int pageIndex, int pageSize, string orderBy)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }

            if (select != null)
                queryable = queryable.Select(select);
            PagedList<E> pagedList = new PagedList<E>(queryable);
            await pagedList.ToPageAsync(pageIndex, pageSize, orderBy);
            return pagedList;
        }

        public async Task<PagedList<E>> GetAsync(Expression<Func<E, bool>>[] expressions, int pageIndex, int pageSize, string orderBy)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            PagedList<E> pagedList = new PagedList<E>(queryable);
            await pagedList.ToPageAsync(pageIndex, pageSize, orderBy);
            return pagedList;
        }

        public async Task<PagedList<E>> GetAsync(Expression<Func<E, bool>>[] expressions, int pageIndex, int pageSize, string orderBy, IConfigurationProvider mapperConfiguration)
        {
            var queryable = Queryable.Where(e => !e.Deleted);
            foreach (var expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            queryable = queryable.ProjectTo<E>(mapper.ConfigurationProvider);
            PagedList<E> pagedList = new PagedList<E>(queryable);
            await pagedList.ToPageAsync(pageIndex, pageSize, orderBy);
            return pagedList;
        }
    }
}

using KTApps.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KTApps.Core.EF
{
    public interface IDomainRepository<T> where T : KTAppDomain
    {
        IQueryable<T> GetQueryable();
        void Create(T entity);
        Task CreateAsync(T entity);
        void Create(IList<T> entities);
        Task CreateAsync(IList<T> entities);
        void AddOrUpdate(T entity);
        void Update(T entity);
        void Update(T entity, params string[] properties);
        void Delete(T entity);
        void Delete(IList<T> entities);
        void Attach(T item);
        void Detach(T entity);
        void SetEntityState(T item, EntityState entityState);
        void LoadReference(T item, params string[] property);
        void LoadCollection(T item, params string[] property);
        int ExecuteNonQuery<P>(string commandText, P[] sqlParameters) where P : DbParameter;
        int ExecuteNonQuery(string commandText, IDictionary<string, object> parameters);
        int ExecuteNonQuery(string commandText);
        DataTable ExcuteQuery<P>(string commandText, P[] sqlParameters) where P : DbParameter;
    }
}

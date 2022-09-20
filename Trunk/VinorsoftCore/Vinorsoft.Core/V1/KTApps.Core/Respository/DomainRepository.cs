using KTApps.Core.Factory;
using KTApps.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Linq.Expressions;
using System.Data.Common;

namespace KTApps.Core.EF
{
    public abstract class DomainRepository<T> : IDomainRepository<T> where T : KTAppDomain
    {
        protected readonly ICoreDbContext Context;

        public DomainRepository(ICoreDbContext context)
        {
            Context = context;
        }
        public DomainRepository(IDbContextFactory dbContextFactory)
        {
            Context = dbContextFactory.Create();
        }

        public virtual void SetEntityState(T item, EntityState entityState)
        {
            Context.Entry(item).State = entityState;
        }

        public virtual void Attach(T item)
        {
            Context.Set<T>().Attach(item);
        }

        public virtual void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual async Task CreateAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public virtual void Create(IList<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
        public virtual async Task CreateAsync(IList<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public virtual void AddOrUpdate(T entity)
        {
            Context.Set<T>().AddOrUpdate<T>(entity);
        }

        public virtual void Update(T entity)
        {
            //Context.Entry(entity).State = EntityState.Modified;
            Context.Set<T>().Update(entity);
        }

        public virtual void Update(T entity, params string[] properties)
        {
            foreach (var prop in properties)
            {
                Context.Entry(entity).Property(prop).IsModified = true;
            }
        }

        public virtual void Detach(T entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual void Delete(IList<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public virtual IQueryable<T> GetQueryable()
        {
            return Context.Set<T>().Where(e => !e.Deleted);
        }

        public virtual void LoadReference(T item, params string[] property)
        {
            foreach (var prop in property)
            {
                Context.Entry(item).Reference(prop).Load();
            }
        }

        public virtual void LoadCollection(T item, params string[] property)
        {
            foreach (var prop in property)
            {
                Context.Entry(item).Collection(prop).Load();
            }
        }

        public DataTable ExcuteQuery<P>(string commandText, P[] sqlParameters) where P : DbParameter
        {
            DataTable dataTable = new DataTable();
            DbConnection connection = null;
            DbCommand command = null;
            try
            {
                connection = Context.Database.GetDbConnection();
                command = connection.CreateCommand();
                connection.Open();
                command.CommandText = commandText;
                command.Parameters.AddRange(sqlParameters);
                DbDataReader dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);
                return dataTable;
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

                if (command != null)
                    command.Dispose();
            }
        }

        public int ExecuteNonQuery(string commandText, IDictionary<string, object> parameters)
        {
            DbConnection connection = null;
            DbCommand command = null;
            try
            {
                connection = Context.Database.GetDbConnection();
                command = connection.CreateCommand();
                connection.Open();
                command.CommandText = commandText;
                foreach (var key in parameters.Keys)
                {
                    var param = command.CreateParameter();
                    param.ParameterName = key;
                    param.Value = parameters[key];
                    command.Parameters.Add(param);
                }
                return command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

                if (command != null)
                    command.Dispose();
            }
        }

        public int ExecuteNonQuery<P>(string commandText, P[] sqlParameters) where P : DbParameter
        {
            DbConnection connection = null;
            DbCommand command = null;
            try
            {
                connection = Context.Database.GetDbConnection();
                command = connection.CreateCommand();
                connection.Open();
                command.CommandText = commandText;
                command.Parameters.AddRange(sqlParameters);
                return command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

                if (command != null)
                    command.Dispose();
            }
        }

        public int ExecuteNonQuery(string commandText)
        {
            DbConnection connection = null;
            DbCommand command = null;
            try
            {
                connection = Context.Database.GetDbConnection();
                command = connection.CreateCommand();
                connection.Open();
                command.CommandText = commandText;
                return command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

                if (command != null)
                    command.Dispose();
            }
        }
    }
}

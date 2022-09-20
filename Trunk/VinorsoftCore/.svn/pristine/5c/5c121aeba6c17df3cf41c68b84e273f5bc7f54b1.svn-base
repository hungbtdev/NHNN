using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Vinorsoft.Core.Mongo.Interface
{
    public interface IMongoContext : IDisposable
    {
        IMongoDatabase Database { get; }
        IMongoCollection<TEntity> DbSet<TEntity>() where TEntity : class ;
        IMongoCollection<TEntity> DbSet<TEntity>(string collectionName) where TEntity : class;
        Task<TEntity> Add<TEntity>(TEntity obj) where TEntity : class;
        Task<TEntity> Update<TEntity>(string id, TEntity obj) where TEntity : class;
        Task<bool> Remove<TEntity>(string id) where TEntity : class;
    }
}

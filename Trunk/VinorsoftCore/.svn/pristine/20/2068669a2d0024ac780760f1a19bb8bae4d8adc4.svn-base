using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Vinorsoft.Core.Mongo.Interface;

namespace Vinorsoft.Core.MongoDbContext
{
    public abstract class MongoContext : IMongoContext
    {
        protected MongoContext(IMongoDbSettings connectionSetting)
        {
            var client = new MongoClient(connectionSetting.ConnectionString);
            Database = client.GetDatabase(connectionSetting.DatabaseName);
        }
        public IMongoDatabase Database { get; }

        public IMongoCollection<TEntity> DbSet<TEntity>() where TEntity: class
        {
            return Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> Add<TEntity>(TEntity obj) where TEntity : class
        {
            await DbSet<TEntity>().InsertOneAsync(obj);
            return obj;
        }
        public async virtual Task<TEntity> Update<TEntity>(string id, TEntity obj) where TEntity : class
        {
            await DbSet<TEntity>().ReplaceOneAsync(FilterId<TEntity>(id), obj);
            return obj;
        }

        public async virtual Task<bool> Remove<TEntity>(string id) where TEntity : class
        {
            var result = await DbSet<TEntity>().DeleteOneAsync(FilterId<TEntity>(id));
            return result.IsAcknowledged;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        private static FilterDefinition<TEntity> FilterId<TEntity>(string key)
        {
            return Builders<TEntity>.Filter.Eq("Id", key);
        }

        public IMongoCollection<TEntity> DbSet<TEntity>(string collectionName) where TEntity : class
        {
            return Database.GetCollection<TEntity>(collectionName);

        }
    }
}

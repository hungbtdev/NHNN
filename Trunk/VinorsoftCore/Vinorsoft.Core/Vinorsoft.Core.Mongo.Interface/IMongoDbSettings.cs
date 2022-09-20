using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.Core.Mongo.Interface
{
    public interface IMongoDbSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

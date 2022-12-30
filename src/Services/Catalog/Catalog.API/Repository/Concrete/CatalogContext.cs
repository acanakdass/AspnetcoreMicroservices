using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Domain.Entities;
using Catalog.API.Repository.Abstract;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Repository.Concrete
{
    public class CatalogContext : ICatalogContext
    {

        
        public CatalogContext(IConfiguration configuration)
        {
            var dbName = configuration.GetValue<string>("DatabaseSettings:DatabaseName");
            var conString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var collectionName = configuration.GetValue<string>("DatabaseSettings:CollectionName");
            var client = new MongoClient(conString); 
            var database = client.GetDatabase(dbName);
            Products = database.GetCollection<Product>(collectionName);
        }

        public IMongoCollection<Product> Products { get; }
    }
}

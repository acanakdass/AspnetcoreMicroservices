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
            var client = new MongoClient(conString); 
            Database= client.GetDatabase(dbName);
        }

        public IMongoDatabase Database { get; }
    }
}

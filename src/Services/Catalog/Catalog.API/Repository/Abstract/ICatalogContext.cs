using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Domain.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repository.Abstract
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}

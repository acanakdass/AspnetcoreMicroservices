using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Domain.Entities;
using Catalog.API.Repository.Abstract;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private IMongoCollection<Product> _products;

        public ProductRepository(ICatalogContext context, IConfiguration configuration)
        {
            var productsCollectionName = configuration.GetValue<string>("DatabaseSettings:ProductsCollectionName");
            _products = context.Database.GetCollection<Product>(productsCollectionName);

            CatalogSeed.SeedData(_products);
        }

        public async Task Create(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _products.DeleteOneAsync(filter);
            var result = deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            return result;
        }

        public async Task<Product> Get(string id)
        {
            var result = await _products.Find(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await _products.Find(x => true).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            var result = await _products.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            var result = await _products.Find(filter).ToListAsync();
            return result;
        }

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            var result = updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Domain.Entities;
using Catalog.API.Repository.Abstract;
using MongoDB.Driver;

namespace Catalog.API.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
            var result = deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            return result;
        }

        public async Task<Product> Get(string id)
        {
            var result = await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await _context.Products.Find(x => true).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            var result = await _context.Products.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);

            var result = await _context.Products.Find(filter).ToListAsync();
            return result;
        }

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            var result = updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            return result;
        }
    }
}

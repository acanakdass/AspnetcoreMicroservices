using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Business.Abstract;
using Catalog.API.Domain.Entities;
using Catalog.API.Repository.Abstract;

namespace Catalog.API.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Product product)
        {
            await _repository.Create(product);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _repository.Delete(id);
            return result;
        }

        public  async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = await _repository.GetAll();
            return result;
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName)
        {
            var result = await _repository.GetByCategory(categoryName);
            return result;
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            var result = await _repository.Get(id);
            return result;
        }

        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            var result = await _repository.GetByName(name);
            return result;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var result = await _repository.Update(product);
            return result;
        }
    }
}

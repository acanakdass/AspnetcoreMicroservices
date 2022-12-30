using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Domain.Entities;

namespace Catalog.API.Business.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task<IEnumerable<Product>> GetByNameAsync(string name);
        Task<IEnumerable<Product>> GetByCategoryAsync(string categoryName);
        Task CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(string id);
    }
}

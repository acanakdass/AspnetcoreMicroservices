using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Domain.Entities;

namespace Catalog.API.Repository.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(string id);
        Task<IEnumerable<Product>> GetByName(string name);
        Task<IEnumerable<Product>> GetByCategory(string categoryName);
        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
    
}

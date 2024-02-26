using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository 
    {
        Task<Product> CreateAsync(Product product);
        Task<Product> GetByIdAsync(int? id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> RemoveAsync(Product product);
        Task<Product> UpdateAsync(Product product);
    }
}

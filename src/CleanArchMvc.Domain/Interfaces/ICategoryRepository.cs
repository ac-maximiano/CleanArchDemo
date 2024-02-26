using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category> GetByIdAsync(int? id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> RemoveAsync(Category category);
        Task<Category> UpdateAsync(Category category);
    }
}

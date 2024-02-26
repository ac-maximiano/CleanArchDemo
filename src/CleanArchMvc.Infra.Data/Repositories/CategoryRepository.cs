using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : CommonRepository<Category>, ICategoryRepository
    {
        protected ApplicationDbContext _categoryContext;    
        public CategoryRepository(ApplicationDbContext context) : base(context)
            => _categoryContext = context;

        public async Task<Category> GetByIdAsync(int? id) => await _categoryContext.Categories.SingleOrDefaultAsync(e => e.Id == id);
        public async Task<IEnumerable<Category>> GetCategoriesAsync() => await _categoryContext.Categories.ToListAsync();
    }
}

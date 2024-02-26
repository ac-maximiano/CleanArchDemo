using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        protected ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext productContext) : base(productContext)
            => _productContext = productContext;

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync() => await _productContext.Products.ToListAsync();
    }
}
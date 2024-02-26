using CleanArchMvc.Infra.Data.Context;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public abstract class CommonRepository<TEntity>
        where TEntity : class
    {
        protected ApplicationDbContext _context;
        public CommonRepository(ApplicationDbContext context) => _context = context;

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

    

using ProjectCleanArch.Data.Context;
using System.Data.Entity;

namespace ProjectCleanArch.Data.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        
    }
}
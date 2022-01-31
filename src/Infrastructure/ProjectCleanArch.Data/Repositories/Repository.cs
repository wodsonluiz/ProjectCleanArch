using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectCleanArch.Data.Context;
using ProjectCleanArch.Domain.Interfaces;

namespace ProjectCleanArch.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }

        public async Task CreateAsync(T entity) => 
            await _dbSet.AddAsync(entity);

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is not null)
                return _dbSet.Where(predicate);

            return _dbSet.AsEnumerable();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate) => 
            await _dbSet.FirstOrDefaultAsync(predicate);
        

        public void RemoveAsync(T entity) =>  
            _dbSet.Remove(entity);
        

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            if (_context != null) _context.Dispose();

            GC.SuppressFinalize(this);
        }

        public void Save() => _context.SaveChanges();
    }
}
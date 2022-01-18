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
        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            return entity;
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if(filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(
                new char[] {','}, StringSplitOptions.RemoveEmptyEntries
            ))
            {
                query = query.Include(includeProperty);
            }

            if(orderBy != null)
                return await orderBy(query).ToListAsync();
            else
                return await query.ToListAsync();   
        }

        public async Task<T> RemoveAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Deleted)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectCleanArch.Domain.Interfaces
{
    public  interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T entity);
        void Update(T entity);
        void RemoveAsync(T entity);
        void Save();
    }
}
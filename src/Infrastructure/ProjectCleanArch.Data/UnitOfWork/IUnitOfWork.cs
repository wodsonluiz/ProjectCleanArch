using Microsoft.EntityFrameworkCore;

namespace ProjectCleanArch.Data.UnitOfWork
{
    public interface IUnitOfWork<out TContext> where TContext : DbContext, new()
    {
         TContext Context { get; }
         void CreateTransaction();
         void Commit();
         void Rollback();
         void Save();
    }
}
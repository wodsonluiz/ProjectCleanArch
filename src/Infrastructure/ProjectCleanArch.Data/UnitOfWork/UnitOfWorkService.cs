using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectCleanArch.Data.UnitOfWork
{
    //Continuar a ler isso: https://dotnettutorials.net/lesson/unit-of-work-csharp-mvc/
    public class UnitOfWorkService<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext, new()
    {
        private readonly TContext _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;
        private DbContextTransaction _objTran;
        private Dictionary<string, object> _repositories;

        public UnitOfWorkService()
        {
            _context = new TContext();
        }

        public TContext Context
        {
            get { return _context; }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void CreateTransaction()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if(_context != null) _context.Dispose();

            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
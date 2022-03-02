using System;
using Microsoft.EntityFrameworkCore;
using ProjectCleanArch.Data.Context;
using ProjectCleanArch.Data.Repositories;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Data
{
    public class UnitOfWork: IDisposable
    {
        private readonly ApplicationDbContext _context;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Category> _categoryRepository;
        private bool disposed = false;

        public UnitOfWork(DbContextOptions<ApplicationDbContext> options)
        {
            _context = new ApplicationDbContext(options);
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new GenericRepository<Product>(_context);
                }
                return _productRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
    }
}
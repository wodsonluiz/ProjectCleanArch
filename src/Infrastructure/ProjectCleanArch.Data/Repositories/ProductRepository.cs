using Microsoft.EntityFrameworkCore;
using ProjectCleanArch.Data.Context;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _context.Products
            .Include(c => c.Category)
            .ToListAsync();

            return products;
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}

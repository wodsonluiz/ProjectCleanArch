using ProjectCleanArch.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetByIdAsync(int? id);
        Task<Product> CreateAsync(Product category);
        Task<Product> UpdateAsync(Product category);
        Task<Product> RemoveAsync(Product category);
    }
}

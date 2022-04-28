using ProjectCleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetByIdAsync(int? id);
        Task<ProductDto> AddAsync(ProductDto productDTO);
        Task<ProductDto> UpdateAsync(ProductDto productDTO);
        Task RemoveAsync(int? id);
    }
}

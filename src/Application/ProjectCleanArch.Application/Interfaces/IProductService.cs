using ProjectCleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task<ProductDTO> AddAsync(ProductDTO productDTO);
        Task<ProductDTO> UpdateAsync(ProductDTO productDTO);
        Task RemoveAsync(int? id);
    }
}

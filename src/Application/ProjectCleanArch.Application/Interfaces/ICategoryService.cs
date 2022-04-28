using ProjectCleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetByIdAsync(int? id);

        Task<CategoryDto> AddAsync(CategoryDto categoryDTO);
        Task<CategoryDto> UpdateAsync(CategoryDto categoryDTO);
        Task RemoveAsync(int? id);
    }
}

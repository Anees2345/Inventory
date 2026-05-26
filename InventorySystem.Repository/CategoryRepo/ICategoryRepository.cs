using InventorySystem.API.Dtos;
using InventorySystem.API.Model;

namespace InventorySystem.Repository.CategoryRepo
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllAsync();

        Task<CategoryDto?> GetByIdAsync(int id);

        Task AddAsync(CategoryDto dto);

        Task UpdateAsync(CategoryDto dto);

        Task DeleteAsync(int id);
    }
}

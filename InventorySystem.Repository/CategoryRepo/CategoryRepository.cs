using InventorySystem.API.Data;
using InventorySystem.API.Dtos;
using InventorySystem.API.Model;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Repository.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _context.Categories
                .Where(x => !x.IsDeleted)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(CategoryDto dto)
        {
            var entity = new Category
            {
                Name = dto.Name
            };

            await _context.Categories.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryDto dto)
        {
            var entity = await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (entity != null)
            {
                entity.Name = dto.Name;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);

            if (entity != null)
            {
                entity.IsDeleted = true;

                await _context.SaveChangesAsync();
            }
        }
    }
}

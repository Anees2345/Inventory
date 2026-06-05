using InventorySystem.API.Data;
using InventorySystem.API.Dtos;
using InventorySystem.API.Model;
using InventorySystem.Repository.CategoryRepo;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _repository.GetAllAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.AddAsync(dto);

            return Ok("Category Added Successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Id mismatch.");
            }

            await _repository.UpdateAsync(dto);

            return Ok(new
            {
                Message = "Category updated successfully."
            });
        }

    }
}

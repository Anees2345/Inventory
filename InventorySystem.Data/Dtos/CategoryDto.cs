using System.ComponentModel.DataAnnotations;

namespace InventorySystem.API.Dtos
{
    public class CategoryDto
    {
        public int? Id { get; set; }   

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
    }
}

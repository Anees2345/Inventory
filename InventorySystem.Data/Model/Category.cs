using System.ComponentModel.DataAnnotations;

namespace InventorySystem.API.Model
{
    public class Category : BaseEntity
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Product>? Products { get; set; }
    }
}

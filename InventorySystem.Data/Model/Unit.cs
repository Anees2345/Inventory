using System.ComponentModel.DataAnnotations;

namespace InventorySystem.API.Model
{
    public class Unit :BaseEntity
    {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    }
} 

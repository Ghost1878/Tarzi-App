using System.ComponentModel.DataAnnotations;

namespace Tarzi_Backend.Models
{
    public class Product : Shared
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Tarzi_Backend.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
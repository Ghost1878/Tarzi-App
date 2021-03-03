using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarzi_Backend.Models
{
    public class Category : Shared
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; }
    }
}
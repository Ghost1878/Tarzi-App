using System;
using System.ComponentModel.DataAnnotations;

namespace Tarzi_Backend.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
}
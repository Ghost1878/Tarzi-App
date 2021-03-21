using System;
using System.ComponentModel.DataAnnotations;
using Tarzi_Backend.ViewModels;

namespace Tarzi_Backend.Models
{
    public class Order : Shared
    {
        [Key]
        public int Id { get; set; }


        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


        public int OrderDetailsId { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }

        public DateTime ReceiptDate { get; set; }
    }

}
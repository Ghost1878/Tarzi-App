using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarzi_Backend.Models
{
    public class Order : Shared
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int OrderDetailsId { get; set; }
        [ForeignKey("OrderDetailsId")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }

}
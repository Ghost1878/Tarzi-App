using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarzi_Backend.Models
{
    public class Order : Shared
    {
        [Key]
        public int Id { get; set; }


        public int CategoryId { get; set; }
        //  [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public DateTime ReceiptDate { get; set; }

        // [ForeignKey("OrderDetailsId")]
        public int OrderDetailsId { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }

    }

}
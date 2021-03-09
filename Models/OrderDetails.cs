using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tarzi_Backend.Models
{
    public class OrderDetails : Shared
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [Required]
        public DateTime ReceiptDate { get; set; }

        [Required]
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
        public double ReceiptMonay { get; set; }
        public double RemanentMonay { get; set; }

        /***   Measures   ***/
        public int Longness { get; set; }
        public int Shoulder { get; set; }
        public int SleeveLength { get; set; }
        public int Sleevewasae { get; set; }
        public int Neck { get; set; }
        public int Side { get; set; }


        /******  Drapery from  ******/
        public string DraperyFrom { get; set; }
        public int DarperyNeededLength { get; set; }

        /********* customer details ********/
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string CustomerType { get; set; }
    }
}

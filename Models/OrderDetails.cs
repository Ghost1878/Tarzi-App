using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tarzi_Backend.Models
{
    public class OrderDetails:Shared
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

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
    }
}

using System;
using System.Collections.Generic;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerPhone { get; set; }
        public string FullName { get; set; }
        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }
        public string CustomerType { get; set; } = "عميل";

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int OrderId { get; set; }
        public int Quntity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
        public double ReceiptMonay { get; set; }
        public double RemanentMonay { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime ReceiptDate { get; set; }

        /** measures**/
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
        public int Longness { get; set; }
        public int Shoulder { get; set; }
        public int SleeveLength { get; set; }
        public int Sleevewasae { get; set; }
        public int Neck { get; set; }
        public int Side { get; set; }


        public string DraperyFrom { get; set; }
        public int DarperyNeededLength { get; set; }

    }
}

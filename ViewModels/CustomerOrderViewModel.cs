using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.ViewModels
{
    public class CustomerOrderViewModel : Shared
    {


        public int Id { get; set; }


        public int CustomerId { get; set; }
        public int CustomerPhone { get; set; }
        public string FullName { get; set; }
        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }


        
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

        public bool DraperyFrom { get; set; }
        public bool DraperyLength { get; set; }
        public string CustomerType { get; set; } = "عميل مسجل";
        public string[] CustomerTypes = new[] { "عميل مسجل", "زبون" };
    }


}
    /** Customer Type**/
    //  public CustomerType CustomerType { get; set; }
        //public bool CustomerType { get; set; }
        //public  List< CustomerType>  Options { get; set; }
 
//public enum CustomerType
//{
//    Customer, Client
//}
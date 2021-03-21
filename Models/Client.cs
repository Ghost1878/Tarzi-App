using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.ViewModels
{
    public class Client : Shared
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
        }
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; }
    }
}
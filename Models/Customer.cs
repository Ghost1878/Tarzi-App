using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tarzi_Backend.Models
{
    public class Customer : Shared
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "إسم العميل")]
        public string Name { get; set; }
        [Display(Name = "رقم الهاتـف")]

        public int Phone { get; set; }
        [Display(Name = "البريد الإلكتروني")]

        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        //[DisplayFormat(DataFormatString ="{0:yyyy-MM-ddTHH:mm}",ApplyFormatInEditMode =true)]  
    }
}
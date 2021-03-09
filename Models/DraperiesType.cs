using System.ComponentModel.DataAnnotations;

namespace Tarzi_Backend.Models
{
    public class DraperiesType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم القماش")]
        [MaxLength(50)]
        public string DraperyName { get; set; }

        [Display(Name = " وصف القماش")]
        [MaxLength(300)]
        public string Description { get; set; }
        [Display(Name = "  القماش المتوفر (متر)")]

        public int AvailableLength { get; set; }

        //  public double PurchasingPrice { get; set; }
        //public double SellingPrice { get; set; }

    }
}
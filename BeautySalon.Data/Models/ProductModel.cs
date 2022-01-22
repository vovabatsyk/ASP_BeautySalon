using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Data.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        [Display(Name = "Знижка?")]
        public bool IsDiscount { get; set; }
    }
}

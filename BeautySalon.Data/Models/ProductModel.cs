using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Data.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Назва*")]
        public string Name { get; set; }

        [Display(Name = "Ціна")]
        public int Price { get; set; }

        [Display(Name = "Показати?")]
        public bool IsDiscount { get; set; }
    }
}

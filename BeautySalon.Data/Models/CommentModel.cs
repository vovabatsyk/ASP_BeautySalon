using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Data.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Текст")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Імя")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Місто")]
        public string UserCity { get; set; }

        [Display(Name = "Позитивний?")]
        public bool IsPositive { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Data.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Заголовок*")]
        public string Title { get; set; }

        [Display(Name = "Текст*")]
        public string Text { get; set; }

        [Display(Name = "Імя*")]
        public string UserName { get; set; }

        [Display(Name = "Місто*")]
        public string UserCity { get; set; }

        [Display(Name = "Показати?")]
        public bool IsPositive { get; set; }
    }
}

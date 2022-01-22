using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Models
{
    public class PostModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Посилання")]
        public string Link { get; set; }

        [Display(Name = "Показати?")]
        public bool IsShow { get; set; }
    }
}

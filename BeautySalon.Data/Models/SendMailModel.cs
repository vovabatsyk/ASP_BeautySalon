using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Data.Models
{
    public class SendMailModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Text { get; set; }
    }
}

namespace BeautySalon.Data.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public string UserCity { get; set; }
        public bool IsPositive { get; set; }
    }
}

using BeautySalon.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalon.Services
{
    public class CommentService : ICommentService
    {
        private IList<CommentModel> _comments;

        public CommentService()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Title = "Test",
                    Text = "Test",
                    UserName = "Test",
                    UserCity = "Test",
                    IsPositive = false
                },
                new CommentModel
                {
                    Id = 2,
                    Title = "EUPHORIA ЗРОБИЛА МЕНЕ КРАСИВОЮ!",
                    Text = "Вони подбали про моє весілля, всі питали, хто мій стиліст. Чудові ціни, чудовий персонал!",
                    UserName = "Тарас",
                    UserCity = "Львів",
                    IsPositive = true
                },
                new CommentModel
                {
                    Id = 3,
                    Title = "EUPHORIA ЗРОБИЛА МЕНЕ ДИВОВИЖНОЮ!",
                    Text = "Я є постійним клієнтом їхніх послуг, коли я завітаю до них, я стаю інша людина",
                    UserName = "Оксана",
                    UserCity = "Києв",
                    IsPositive = true
                },

            };
        }

        public void CreateModel(CommentModel comment)
        {
            _comments.Add(comment);
        }

        public bool DeleteModel(CommentModel comment)
        {
            var deletedcomment = _comments.FirstOrDefault(p => p.Id == comment.Id);
            if (deletedcomment == null)
            {
                return false;
            }

            _comments.Remove(deletedcomment);
            return true;
        }

        public IList<CommentModel> GetAllModels()
        {
            return _comments;
        }

        public CommentModel GetModelById(int id)
        {
            var item = _comments.FirstOrDefault(i => i.Id == id);

            return item;
        }

        public IList<CommentModel> GetPositiveComments()
        {
            return _comments.Where(c => c.IsPositive == true).ToList();
        }

        public CommentModel UpdateModel(CommentModel obj)
        {
            var updatedItem = _comments.FirstOrDefault(i => i.Id == obj.Id);
            _comments.Where(i => i.Id == obj.Id).Select(c =>
            {
                c.Title = obj.Title;
                c.Text = obj.Text;
                c.UserName = obj.UserName;
                c.UserCity = obj.UserCity;
                c.IsPositive = obj.IsPositive;
                return c;
            }).ToList();
            return updatedItem;
        }
    }
}

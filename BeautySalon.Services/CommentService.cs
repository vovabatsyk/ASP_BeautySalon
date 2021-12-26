using BeautySalon.Data.Models;
using System;
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

        public CommentModel CreateOrUpdateModel(CommentModel post)
        {
            throw new NotImplementedException();
        }

        public bool DeleteModel(CommentModel post)
        {
            throw new NotImplementedException();
        }

        public IList<CommentModel> GetAllModels()
        {
            return _comments;
        }

        public CommentModel GetModelById(string id)
        {
            throw new NotImplementedException();
        }

        public IList<CommentModel> GetPositiveComments()
        {
            return _comments.Where(c => c.IsPositive == true).ToList();
        }
    }
}

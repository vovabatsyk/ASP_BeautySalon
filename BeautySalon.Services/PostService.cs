using BeautySalon.Data;
using BeautySalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalon.Services
{
    public class PostService : IPostService
    {
        private IList<PostModel> _posts;
        private readonly ApplicationDbContext _dbContext;

        public PostService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PostService()
        {
            _posts = new List<PostModel>
            {
                new PostModel {
                    Id = 1,
                    Title = "СТАТУСИ ПРО ЗАЧІСКУ",
                    Description = "Статуси про зачіску можуть поставити люди з різних причин: давно мріяли про такий зачісці, але всі боялися поекспериментувати, невдала зачіска, філософські статуси про зачіску і тому, що за нею ховається.",
                    Link = "https://beautiful-lady.com.ua/2020/09/01/%D0%B6%D1%96%D0%BD%D0%BA%D0%B0-%D0%B7%D0%BC%D1%96%D0%BD%D1%8E%D1%94-%D0%B7%D0%B0%D1%87%D1%96%D1%81%D0%BA%D1%83-%D1%86%D0%B8%D1%82%D0%B0%D1%82%D0%B8-%D1%86%D0%B8%D1%82%D0%B0%D1%82%D0%B8-%D0%BF%D1%80/",
                    IsShow = false
                },
                new PostModel
                {
                    Id = 2,
                    Title = "ТОП-10 ЖІНОЧИХ ЗАЧІСОК ДЛЯ СПОКУШАННЯ ЧОЛОВІКІВ",
                    Description = "Я опитала знайомих чоловіків, навмисно внісши до вибірки представників різного віку та професій. Отже, які ж зачіски можуть спокусити практично будь-якого чоловіка?",
                    Link = "https://beautiful-lady.com.ua/2018/02/05/%d0%b7%d0%b0%d1%87%d1%96%d1%81%d0%ba%d0%b8-%d1%8f%d0%ba%d1%96-%d0%bf%d0%be%d0%b4%d0%be%d0%b1%d0%b0%d1%8e%d1%82%d1%8c%d1%81%d1%8f-%d1%85%d0%bb%d0%be%d0%bf%d1%86%d1%8f%d0%bc-%d0%b6%d1%96%d0%bd%d0%be/",
                    IsShow = false
        },
                new PostModel
                {
                    Id = 3,
                    Title = "ЗАЧІСКА ДО ПЛАТТЯ З ВІДКРИТИМИ ПЛЕЧИМА",
                    Description = "Кожен виріз має свої лінії і вирішує персональні завдання: геометричний контур, плавний вигин, смілива демонстрація краси і т. Д. Тому і доречність зачіски теж індивідуальна.",
                    Link = "https://beautiful-lady.com.ua/2020/01/07/%d0%b7%d0%b0%d1%87%d1%96%d1%81%d0%ba%d0%b0-%d0%bf%d1%96%d0%b4-%d0%b2%d0%b8%d1%80%d1%96%d0%b7-%d1%81%d1%83%d0%ba%d0%bd%d1%96-%d1%84%d0%be%d1%82%d0%be-100-%d1%84%d0%be%d1%82%d0%be-%d0%bc%d0%be%d0%b4/",
                    IsShow = false
        },
                new PostModel
                {
                    Id = 4,
                    Title = "Зачіски з фатою для весілля на середні волосся фото: Весільні зачіски на середні волосся з фатою і без фати.",
                    Description = "В процесі створення весільної зачіски перукар стиліст користується лаком і плойкою. Важливо розуміти, чим більше локонів на голові, тим більше коштів укладання для додання їм форми використовує майстер.Якщо ж волосся щільно заплетене і зав’язані в пучок, то можна обійтися практично без лаку.",
                    Link = "https://beautiful-lady.com.ua/2017/10/17/%d0%b7%d0%b0%d1%87%d1%96%d1%81%d0%ba%d0%b8-%d0%b7-%d1%84%d0%b0%d1%82%d0%be%d1%8e-%d0%b4%d0%bb%d1%8f-%d0%b2%d0%b5%d1%81%d1%96%d0%bb%d0%bb%d1%8f-%d0%bd%d0%b0-%d1%81%d0%b5%d1%80%d0%b5%d0%b4%d0%bd%d1%96/",
                    IsShow = false
        }
            };
        }

        public IList<PostModel> GetAllModels()
        {
            return _dbContext.PostModels.ToList();
        }

        public PostModel GetModelById(string id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateOrUpdateModel(PostModel post)
        {
            _dbContext.PostModels.Add(post);
            _dbContext.SaveChanges();
        }

        public bool DeleteModel(PostModel post)
        {
            throw new System.NotImplementedException();
        }
    }
}

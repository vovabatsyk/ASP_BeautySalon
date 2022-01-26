using BeautySalon.Data;
using BeautySalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalon.Services
{
    public class PostService : IPostService
    {

        private readonly ApplicationDbContext _dbContext;

        public PostService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<PostModel> GetAllModels()
        {
            return _dbContext.PostModels.ToList();
        }


        public PostModel GetModelById(int id)
        {
            return _dbContext.PostModels.FirstOrDefault(model => model.Id == id);
        }

        public void CreateModel(PostModel model)
        {
            _dbContext.PostModels.Add(model);
            _dbContext.SaveChanges();
        }

        public bool DeleteModel(PostModel obj)
        {
            var model = _dbContext.PostModels.Find(obj.Id);
            _dbContext.PostModels.Remove(model);
            _dbContext.SaveChanges();
            return true;
        }

        public void UpdateModel(PostModel obj)
        {
            _dbContext.PostModels.Update(obj);
            _dbContext.SaveChanges();
        }


        public IList<PostModel> ShowPosts()
        {
            return _dbContext.PostModels.Where(p => p.IsShow == true).ToList();
        }
    }
}

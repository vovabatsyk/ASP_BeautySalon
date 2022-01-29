using BeautySalon.Data;
using BeautySalon.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalon.Services
{
    public class CommentService : ICommentService
    {

        private readonly ApplicationDbContext _dbContext;

        public CommentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateModel(CommentModel model)
        {
            _dbContext.CommentModels.Add(model);
            _dbContext.SaveChanges();
        }

        public bool DeleteModel(CommentModel obj)
        {
            var model = _dbContext.CommentModels.Find(obj.Id);
            _dbContext.CommentModels.Remove(model);
            _dbContext.SaveChanges();
            return true;
        }

        public IList<CommentModel> GetAllModels()
        {
            return _dbContext.CommentModels.ToList();
        }

        public CommentModel GetModelById(int id)
        {
            return _dbContext.CommentModels.FirstOrDefault(model => model.Id == id);
        }

        public IList<CommentModel> GetPositiveComments()
        {
            return _dbContext.CommentModels.Where(p => p.IsPositive == true).ToList();
        }

        public void UpdateModel(CommentModel obj)
        {
            _dbContext.CommentModels.Update(obj);
            _dbContext.SaveChanges();

        }
    }
}

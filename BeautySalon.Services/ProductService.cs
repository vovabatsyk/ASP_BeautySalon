using BeautySalon.Data;
using BeautySalon.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalon.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<ProductModel> GetAllModels()
        {
            return _dbContext.ProductModels.ToList();
        }

        public IList<ProductModel> ShowProducts()
        {
            return _dbContext.ProductModels.Where(p => p.IsDiscount == true).ToList();
        }
        public void CreateModel(ProductModel model)
        {
            _dbContext.ProductModels.Add(model);
            _dbContext.SaveChanges();
        }

        public bool DeleteModel(ProductModel odj)
        {
            var model = _dbContext.ProductModels.Find(odj.Id);
            _dbContext.ProductModels.Remove(model);
            _dbContext.SaveChanges();
            return true;
        }

        public ProductModel GetModelById(int id)
        {
            return _dbContext.ProductModels.FirstOrDefault(model => model.Id == id);

        }

        public void UpdateModel(ProductModel obj)
        {
            _dbContext.ProductModels.Update(obj);
            _dbContext.SaveChanges();
        }

        public bool LimitShowProduct(int count)
        {
            var modelsLength = _dbContext.ProductModels.Where(p => p.IsDiscount == true).ToList().Count;
            if (modelsLength >= count) return false;
            return true;
        }
    }
}

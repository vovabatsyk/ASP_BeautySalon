using BeautySalon.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalon.Services
{
    public class ProductService : IProductService
    {
        private IList<ProductModel> _products;
        public ProductService()
        {
            _products = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = 1,
                    Name = "Test",
                    Price = 100,
                    IsDiscount = false
                },
                new ProductModel
                {
                    Id = 2,
                    Name = "Укладка",
                    Price = 50,
                    IsDiscount = true
                },
                new ProductModel
                {
                    Id = 3,
                    Name = "Педікюр",
                    Price = 120,
                    IsDiscount = true
                },
                new ProductModel
                {
                    Id = 4,
                    Name = "Візаж",
                    Price = 250,
                    IsDiscount = true
                }
            };
        }

        public IList<ProductModel> GetAllModels()
        {
            return _products;
        }

        public IList<ProductModel> ShowProducts()
        {
            return _products.Where(p => p.IsDiscount == true).ToList();
        }
        public void CreateModel(ProductModel product)
        {
            this._products.Add(product);
        }

        public bool DeleteModel(ProductModel product)
        {
            var deletedProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (deletedProduct == null)
            {
                return false;
            }

            _products.Remove(deletedProduct);
            return true;
        }

        public ProductModel GetModelById(int id)
        {
            var item = _products.FirstOrDefault(i => i.Id == id);

            return item;
        }

        public ProductModel UpdateModel(ProductModel obj)
        {
            var updatedItem = _products.FirstOrDefault(i => i.Id == obj.Id);
            _products.Where(i => i.Id == obj.Id).Select(c =>
            {
                c.Name = obj.Name;
                c.Price = obj.Price;
                c.IsDiscount = obj.IsDiscount;
                return c;
            }).ToList();
            return updatedItem;
        }
    }
}

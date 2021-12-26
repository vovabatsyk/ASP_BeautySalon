using BeautySalon.Data.Models;
using System;
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

        public IList<ProductModel> GetDiscountProducts()
        {
            return _products.Where(p => p.IsDiscount == true).ToList();
        }
        public ProductModel CreateOrUpdateModel(ProductModel post)
        {
            throw new NotImplementedException();
        }

        public bool DeleteModel(ProductModel post)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetModelById(string id)
        {
            throw new NotImplementedException();
        }
    }
}

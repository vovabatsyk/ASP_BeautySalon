using BeautySalon.Data.Models;
using System.Collections.Generic;

namespace BeautySalon.Services
{
    public interface IProductService : ICommonService<ProductModel>
    {
        public IList<ProductModel> ShowProducts();
    }
}

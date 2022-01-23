using System.Collections.Generic;

namespace BeautySalon.Services
{
    public interface ICommonService<T>
    {
        public IList<T> GetAllModels();
        public T GetModelById(int id);
        public void CreateModel(T post);
        public T UpdateModel(T obj);
        public bool DeleteModel(T post);
    }
}

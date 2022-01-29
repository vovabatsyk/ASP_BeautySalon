using System.Collections.Generic;

namespace BeautySalon.Services
{
    public interface ICommonService<T>
    {
        public IList<T> GetAllModels();
        public T GetModelById(int id);
        public void CreateModel(T post);
        public void UpdateModel(T obj);
        public bool DeleteModel(T post);
    }
}

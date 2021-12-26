using System.Collections.Generic;

namespace BeautySalon.Services
{
    public interface ICommonService<T>
    {
        public IList<T> GetAllModels();
        public T GetModelById(string id);
        public T CreateOrUpdateModel(T post);
        public bool DeleteModel(T post);
    }
}

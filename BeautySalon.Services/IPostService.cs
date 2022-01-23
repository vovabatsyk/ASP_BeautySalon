using BeautySalon.Models;
using System.Collections.Generic;

namespace BeautySalon.Services
{
    public interface IPostService : ICommonService<PostModel>
    {
        public IList<PostModel> ShowPosts();

    }
}

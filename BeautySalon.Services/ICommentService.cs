using BeautySalon.Data.Models;
using System.Collections.Generic;

namespace BeautySalon.Services
{
    public interface ICommentService : ICommonService<CommentModel>
    {
        public IList<CommentModel> GetPositiveComments();
    }
}

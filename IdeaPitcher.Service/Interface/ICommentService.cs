using IdeaPitcher.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Interface
{
    public interface ICommentService
    {
        void postComment(CommentModel comment);

        public IEnumerable<CommentModel> GetComments(int id);

    }
}

using IdeaPitcher.DAL.Models;
using IdeaPitcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Interface
{
    public interface ICommentRepository
    {
        void postComment(CommentModel comment);
        public IEnumerable<CommentModel> GetComments(int id);
    }
}

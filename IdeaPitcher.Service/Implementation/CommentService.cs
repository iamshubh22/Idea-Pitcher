using IdeaPitcher.DAL.Interface;
using IdeaPitcher.DAL.Models;
using IdeaPitcher.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository repository;
        public CommentService(ICommentRepository commentRepository)
        {
            repository = commentRepository;
        }
        public void postComment(CommentModel comment)
        {
            repository.postComment(comment);
        }
        public IEnumerable<CommentModel> GetComments(int id)
        {
            return repository.GetComments(id);
        }

    }
}

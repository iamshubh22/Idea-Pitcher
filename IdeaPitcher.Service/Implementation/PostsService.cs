using IdeaPitcher.DAL.Implementation;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Models;
using IdeaPitcher.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Implementation
{
    public class PostsService : IPostService
    {
        private readonly IPostRepository repository;
        public PostsService(IPostRepository postRepository )
        {
            repository= postRepository;
        }

        public void DeletePost(int id)
        {
           repository.DeletePost(id);
        }

        public IEnumerable<ContentModel> GetPosts()
        {
            return repository.GetPosts();
        }

        public void Promote(int id)
        {
            repository.Promote(id);
        }
    }
}

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
    
    public class PublishService: IPublishService
    {
        private readonly IPostRepository repository;
        public PublishService(IPostRepository postRepository)
        {
            repository = postRepository;
        }

        public void PublishPosts(ContentModel obj) {
            repository.PublishPosts(obj);
        }

    }
}

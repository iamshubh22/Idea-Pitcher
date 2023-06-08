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
    public class DraftService : IDraftService

    {
        private readonly IDraftRepository repository;
        public DraftService(IDraftRepository draftRepository)
        {
            repository = draftRepository;
        }
        public void DraftPosts(ContentModel posts)
        {
            repository.DraftPosts(posts);
        }

        public IEnumerable<ContentModel> getDraftPosts()
        {
            return repository.getDraftPosts();
        }

        public void publishdrafted(int id)
        {
            repository.publishdrafted(id);
        }
    }
}

using IdeaPitcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Interface
{
    public interface IDraftService
    {
        void DraftPosts(ContentModel posts);
        IEnumerable<ContentModel> getDraftPosts();

        void publishdrafted(int id);
    }
}

using IdeaPitcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Interface
{
    public interface IDraftRepository
    {
        void DraftPosts(ContentModel posts);
        IEnumerable<ContentModel> getDraftPosts();

        void publishdrafted(int id);
    }
}

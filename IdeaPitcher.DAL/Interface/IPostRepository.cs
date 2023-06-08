using IdeaPitcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Interface
{
    public interface IPostRepository
    {
        IEnumerable<ContentModel> GetPosts();
        void PublishPosts(ContentModel obj);
        void DeletePost(int id);

        void Promote(int id);
    }
}

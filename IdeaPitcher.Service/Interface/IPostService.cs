using IdeaPitcher.DAL.Models;
using IdeaPitcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace IdeaPitcher.Service.Interface
{
    public interface IPostService
    {
        IEnumerable<ContentModel> GetPosts();

        void DeletePost(int id);
        void Promote(int id);
        
    }
}

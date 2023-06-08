using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Implementation
{
    public class ChangeIdeaRepository : IChangeIdeaRepository
    {
        private readonly ApplicationDbContext _db;
        public ChangeIdeaRepository(ApplicationDbContext db)

        {
            _db = db;
        }
        public void change_ideas(string Userid, int id)

        {
            var post = _db.Posts.Where(x => x.PostId == id).FirstOrDefault();
            if (post != null)
            {
                var user = _db.Users.Where(x => x.Id == Userid).FirstOrDefault();
                post.Tid = user.TeamId; 
                post.createdby = user.UserName;
                _db.Posts.Update(post);
                _db.SaveChanges();
            }

        }
        public ContentModel? Check_Idea(int id)
        {
            var checks = _db.Posts.Find(id);
            var users = _db.Users.ToList();
            var userSelectList = users.Select(u => new SelectListItem { Value = u.Id, Text = u.UserName });
            checks.UserSelectList = userSelectList;
            return checks;
        }
    }

}

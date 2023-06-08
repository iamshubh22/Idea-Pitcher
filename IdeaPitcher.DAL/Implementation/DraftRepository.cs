using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Implementation
{
    
    public class DraftRepository: IDraftRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdeaPitcherUser> _userManager;




        public DraftRepository(ApplicationDbContext db, IHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor, UserManager<IdeaPitcherUser> userManager)

        {
            _hostEnvironment = hostEnvironment;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public void DraftPosts(ContentModel posts)
        {
            var currentUser = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            string filename = null;
            if (posts.Image != null)
            {
                string uploaddir = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot/Ideas/Images");
                filename = Guid.NewGuid().ToString() + "-" + posts.Image.FileName;
                string filepath = Path.Combine(uploaddir, filename);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    posts.Image.CopyTo(filestream);

                }
            }

            posts.IdeaImage = filename;
            posts.Drafted = true;
            posts.Tid = currentUser.TeamId;

            _db.Posts.Add(posts);
            _db.SaveChanges();
        }

        public IEnumerable<ContentModel> getDraftPosts()
        {
            return _db.Posts.Where(x=>x.Drafted==true).ToList();
        }

        public void publishdrafted(int id)
        {
            var content = _db.Posts.Where(x => x.PostId == id).FirstOrDefault();
            if (content != null)
            {
                content.CreatedOn = DateTime.Now;
                content.Drafted=false;
                _db.SaveChanges();
            }

        }
    }
}

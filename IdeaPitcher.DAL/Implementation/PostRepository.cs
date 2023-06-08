using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IdeaPitcher.DAL.Implementation
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdeaPitcherUser> _userManager;




        public PostRepository(ApplicationDbContext db, IHostEnvironment hostEnvironment,IHttpContextAccessor httpContextAccessor, UserManager<IdeaPitcherUser> userManager)

        {
            _hostEnvironment = hostEnvironment;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }


        public IEnumerable<ContentModel> GetPosts()
        {
            var currentUser = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;

            var role = _userManager.GetRolesAsync(currentUser).Result;
            
            if(role.Count == 3)
            {
                IEnumerable<ContentModel> objUserList1 = _db.Posts.Where(x => x.Drafted == false).OrderByDescending(y => y.CreatedOn);
                return objUserList1;
            }
            IEnumerable<ContentModel> objUserList = _db.Posts.Where(x => x.Drafted == false && (x.Tid == currentUser.TeamId || x.isVisible == true)).OrderByDescending(y => y.CreatedOn);

           

            if (_userManager.IsInRoleAsync(currentUser, "SuperAdmin").Result)
            {
                objUserList = _db.Posts.Where(x => !x.Drafted).OrderByDescending(y => y.CreatedOn);
            }
            else
            {
                objUserList = _db.Posts.Where(x => !x.Drafted && (x.Tid == currentUser.TeamId || x.isVisible)).OrderByDescending(y => y.CreatedOn);
            }


            return objUserList;

        }


        public void DeletePost(int id)
        {
            var post = _db.Posts.Where(x=>x.PostId==id).FirstOrDefault();
            _db.Posts.Remove(post);
            _db.SaveChanges();
        }


        public void PublishPosts(ContentModel obj)
        {
            var currentUser = _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            string filename = null;
            if (obj.Image != null)
            {
                string uploaddir = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot/Ideas/Images");
                filename=Guid.NewGuid().ToString()+"-"+ obj.Image.FileName;
                string filepath =Path.Combine(uploaddir, filename);
                using(var filestream = new FileStream(filepath, FileMode.Create))
                {
                    obj.Image.CopyTo(filestream);

                }
            }
          
            obj.IdeaImage = filename;
            obj.Tid = currentUser.TeamId;
            _db.Posts.Add(obj);
            _db.SaveChanges();

        }

        public void Promote(int id)
        {
            var post = _db.Posts.Where(u=>u.PostId==id).FirstOrDefault();
            if(post!= null)
            {
                post.isVisible = true;
            }

            _db.SaveChanges();
            

        }


    }
}


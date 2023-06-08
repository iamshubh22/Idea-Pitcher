using IdeaPitcher.DAL;
using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Models;
using IdeaPitcher.Models;
using IdeaPitcher.Service.Implementation;
using IdeaPitcher.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdeaPitcher.Controllers
{
    
    public class ContentController : Controller
    {

        private readonly IPublishService _postsServicepostsService;
        private readonly IDraftService _draftService;
        //private readonly UserManager<IdeaPitcherUser> _usermanager;
        

        public ContentController(IPublishService postsServicepostsService, IDraftService draftService/*,UserManager<IdeaPitcherUser> usermanager*/)
        {
            _postsServicepostsService = postsServicepostsService;
            _draftService = draftService;
            //_usermanager = usermanager;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<ContentModel> objUserList = _db.;
            return View();
        }


        [HttpPost]
        public IActionResult Index(ContentModel obj)
        {
            //obj.TeamId= _usermanager.GetUserAsync(User).Result.TeamId;
            _postsServicepostsService.PublishPosts(obj);
            return RedirectToAction("Index","Home");
        }
        public IActionResult Draft()
        {

            var draftedposts = _draftService.getDraftPosts();
            return View(draftedposts);
        }
        [HttpPost]
        public IActionResult Draft(ContentModel posts)
        {
            _draftService.DraftPosts(posts);
            return View(_draftService.getDraftPosts());
            

            
        }
        public IActionResult publishDrafted(int id)
        {
            _draftService.publishdrafted(id);
            return RedirectToAction("Index","Home");
        }


    }
}

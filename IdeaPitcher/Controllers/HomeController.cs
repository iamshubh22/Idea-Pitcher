using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Models;
using IdeaPitcher.Models;
using IdeaPitcher.Service.Implementation;
using IdeaPitcher.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IdeaPitcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly ICommentService _commentservice;
        
        public HomeController(ILogger<HomeController> logger, IPostService postService, ICommentService commentService)
        {
            _logger = logger;
            _postService = postService;
            _commentservice = commentService;
            
        }
        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<ContentModel> contents = _postService.GetPosts();
            return View(contents);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            _postService.GetPosts();
            return View();

        }

        [HttpPost]
        public IActionResult Comment(CommentModel commentdata, int id)
        {
            //if (string.IsNullOrWhiteSpace(commentdata.CommentText))
            //{
            //    ModelState.AddModelError("CommentText", "Comment cannot be empty");
            //    return RedirectToAction("Index");
            //}
            
                
                commentdata.AuthorId = id;
                commentdata.Datecreated = DateTime.Now;
                var username = User.Identity.Name.ToString();
                commentdata.Author = username;
                _commentservice.postComment(commentdata);
                return RedirectToAction("Index");

            
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _postService.DeletePost(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Promote(int id) 
        {

            _postService.Promote(id);
            return RedirectToAction("Index");
        
        }

      
    }
}
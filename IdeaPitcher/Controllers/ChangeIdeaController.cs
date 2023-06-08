using IdeaPitcher.Models;
using IdeaPitcher.Service.Implementation;
using IdeaPitcher.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IdeaPitcher.Controllers
{
    public class ChangeIdeaController : Controller
    {
        private readonly IPostService _postService;
        private readonly IChangeIdeaService _ownerChanges;
        private readonly ITeamMappingService _TMrepository;

        public ChangeIdeaController(IPostService postService, IChangeIdeaService ownerChanges, ITeamMappingService TMrepository)
        {
            _postService = postService;
            _ownerChanges = ownerChanges;
            _TMrepository = TMrepository;
        }
        public IActionResult Change_Idea_User()
        {
            IEnumerable<ContentModel> contents = _postService.GetPosts();
            return View(contents);
        }


        public IActionResult Change_Idea_User_Update(int Id)
        {

            if (Id == null)
            {
                return NotFound();
            }
            var checks = _ownerChanges.CheckIdea(Id);
            if (checks == null)
            {
                return NotFound();
            }
            return View(checks);

        }
        [HttpPost]
        public IActionResult Change_Idea_User_Update(int id,string createdby)
        {
            _ownerChanges.ownerChanges(createdby,id);
            return RedirectToAction("Index","Home");
        }
    }
}

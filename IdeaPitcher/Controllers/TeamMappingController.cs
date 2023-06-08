using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Interface;
using IdeaPitcher.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IdeaPitcher.Controllers
{
    public class TeamMappingController : Controller
    {
        private readonly ITeamMappingService _repository;
        public TeamMappingController(ITeamMappingService teamMappingService)
        {
            _repository = teamMappingService;
        }
        public IActionResult Team_Mapping()
        {
            
            return View(_repository.GetUsers());
        }
        [HttpPost]
        public IActionResult Team_Mapping(IEnumerable<IdeaPitcherUser> UserList)
        {
                        

            // Save changes to the database
            _repository.SetTeam(UserList);

            return RedirectToAction("Index", "Home");
        }
    }
}

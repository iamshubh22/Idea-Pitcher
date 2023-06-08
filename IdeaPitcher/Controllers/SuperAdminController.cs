using IdeaPitcher.DAL.Data;
using IdeaPitcher.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdeaPitcher.Service.Implementation;
using IdeaPitcher.Service.Interface;

namespace IdeaPitcher.Controllers
{

    public class SuperAdminController : Controller
    {
        
        private readonly ISuperAdminService _superAdminService;
        public SuperAdminController(ISuperAdminService superAdminService) {
            
            _superAdminService = superAdminService;
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Super()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Createdrop()
        {
            

            return View(_superAdminService.CreateDrop());
            
        }
        [HttpPost]
        public IActionResult CreateTeam(TeamModel teamdata)
        {
            
            _superAdminService.CreateTeam(teamdata);
            return RedirectToAction("Index","Home");

        }
    }
}

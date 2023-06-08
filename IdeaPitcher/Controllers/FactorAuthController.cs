using IdeaPitcher.DAL.Data;
using IdeaPitcher.Models;
using IdeaPitcher.Service.Implementation;
using IdeaPitcher.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IdeaPitcher.Controllers
{
    public class FactorAuthController : Controller
    {
        private readonly IFactorAuthService _factorAuthentication;
        

        public FactorAuthController(IFactorAuthService factorAuthentication)
        {
            
            _factorAuthentication = factorAuthentication;
            
        }

        public IActionResult FactorAuth()
        {
            IEnumerable<IdeaPitcherUser> contents = _factorAuthentication.find_all();
            return View(contents);

        }
        

        public IActionResult Change_FactorAuth(string Id)
        {

            if (Id == null)
            {
                return NotFound();
            }
            var checks = _factorAuthentication.Check_User(Id);
            if (checks == null)
            {
                return NotFound();
            }
            return View(checks);

        }
        [HttpPost]
        public IActionResult Change_FactorAuth(IdeaPitcherUser contentModel)
        {
            _factorAuthentication.FactorAuth(contentModel);
            return View();
        }
    }
}

using IdeaPitcher.DAL.Data;
using IdeaPitcher.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IdeaPitcher.Controllers
{
    public class EnableDisableUserController : Controller
    {
        private readonly IFactorAuthService _factorAuthentication;
        private readonly IEnableDisableUserService _enableDisableUserService;
        public EnableDisableUserController(IFactorAuthService factorAuthentication , IEnableDisableUserService enableDisableUserService)
        {

            _factorAuthentication = factorAuthentication;
            _enableDisableUserService = enableDisableUserService;
        }
        public async Task<IActionResult> Enable_Disable_User()
        {
            IEnumerable<IdeaPitcherUser> contents = _factorAuthentication.find_all();
            return View(contents);
        }

        public async Task<IActionResult> Disable (String Id)
        {
            if (Id != null)
            {
                _enableDisableUserService.Disables(Id);
            }

            return RedirectToAction(nameof(Enable_Disable_User));
        }

        public async Task<IActionResult> Enable(String Id)
        {
            if (Id != null)
            {
                _enableDisableUserService.Enable(Id);
            }

            return RedirectToAction(nameof(Enable_Disable_User));
        }
    }
}

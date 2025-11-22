using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MrIgor.Core.Models;

namespace MrIgor.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AspNetUser> _signInManager;

        public AccountController(SignInManager<AspNetUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

using CleanArchMvc.Domain.Auth.Interfaces;
using CleanArchMvc.Presentation.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;

        public AccountController(IAuthenticate authentication) => 
            _authentication = authentication;

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel()
            {
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _authentication.AuthenticateAsync(model.Email, model.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt. (Password must be strong).");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model) 
        {
            var result = await _authentication.RegisterUser(model.Email, model.Password);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong).");
                
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return RedirectToAction("Login");
        }
    }
}

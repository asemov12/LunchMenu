using LunchMenu.Service.DTOs.Authentication;
using LunchMenu.Service.Interfaces;
using LunchMenu.Web.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LunchMenu.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _authenticationService.AuthenticateAsync
                (new LoginRequest {
                    Username = model.Username,
                    Password = model.Password 
                });

            if (user == null || !user.Success)
            {
                ViewData["ErrorMessage"] = user.ErrorMessage ?? "Invalid username or password";
                return View(model);
            }
            // Save to session
            HttpContext.Session.SetString("Name", user.Name!);
            HttpContext.Session.SetInt32("CustomerId", user.CustomerId ?? 0);
            HttpContext.Session.SetString("Username", model.Username);

            return RedirectToAction("Index", "Home"); // or wherever you want to go
        }
    }
}

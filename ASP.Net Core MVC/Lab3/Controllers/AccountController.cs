using Lab3.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lab3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model , string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                // Check in Database
                if (model.Name == "Ahmed" || model.Name == "Ali" || model.Name == "Sara")
                {
                    // After Check on Database
                    Claim c1 = new Claim(ClaimTypes.Name, model.Name);
                    Claim c2 = new Claim(ClaimTypes.Email, "k@gmail.com");
                    Claim c3;
                    switch (model.Name)
                    {
                        case "Ahmed":
                            c3 = new Claim(ClaimTypes.Role, "Admin");
                            break;
                        case "Ali":
                            c3 = new Claim(ClaimTypes.Role, "Student");
                            break;
                        case "Sara":
                            c3 = new Claim(ClaimTypes.Role, "Instructor");
                            break;
                        default:
                            c3 = new Claim(ClaimTypes.Role, "Student");
                            break;
                    }


                    ClaimsIdentity ci = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                    ci.AddClaim(c1);
                    ci.AddClaim(c2);
                    ci.AddClaim(c3);

                    ClaimsPrincipal cp = new ClaimsPrincipal(ci);

                    await HttpContext.SignInAsync(cp);

                    if (ReturnUrl != null) return LocalRedirect(ReturnUrl);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid Username or Password");
            return View();

        }
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

using Library.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class AuthenController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(AdminDTO admin)
        {
            if(admin.admin_Name == "khanh@gmail.com" &&
                admin.Password == "123")
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,admin.admin_Name),
                    new Claim("Other","Example")
                };

                ClaimsIdentity claimsidentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = admin.delete_Flag,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsidentity), properties);

                return RedirectToAction("Index","Home");
            }

            ViewData["ValidateMessage"] = "admin not found";
            return View();
        }
    }
}

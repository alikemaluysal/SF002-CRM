using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Company.Crm.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model, string? returnUrl)
        {
            // Login işlemi

            // Claim - Ad
            // Identity - Kimlik, Ehliyet, KurumKarti, YemekKarti
            // Principle - Cuzdan (Kimlik, Ehliyet)

            if (ModelState.IsValid)
            {
                var user = userService.Login(model);

                if (user != null)
                {
                    #region Claim, Identity, Principle
                    // ClaimsIdentity içerisindeki bilgiler (Kimlik'te yazan bilgiler)
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Surname, user.Surname),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    //if (!string.IsNullOrEmpty(user.Roles))
                    //{
                    //    string[] roles = user.Roles.Split(";");
                    //    foreach (var role in roles)
                    //    {
                    //        claims.Add(new Claim(ClaimTypes.Role, role));
                    //    }
                    //}

                    // ClaimsIdentity (Kimlik)
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Principle (Cüzdan)
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

                    #endregion

                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = DateTime.Now.AddDays(30)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrinciple,
                        authProperties
                    );

                    return Redirect(returnUrl == null ? "/" : returnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre yanlış");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.Register(model);
                if (user != null)
                {

                    // Email Activation

                    return RedirectToAction("Login");
                }
            }

            ModelState.AddModelError(string.Empty, "Kayıt sırasında bir hata oluştu");

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult RemindPassword()
        {
            return View();
        }
    }
}

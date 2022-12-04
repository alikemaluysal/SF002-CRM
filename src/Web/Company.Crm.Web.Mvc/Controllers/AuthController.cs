using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Company.Crm.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
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
                var user = _userService.Login(model);

                if (user != null)
                {
                    #region Claim, Identity, Principle

                    // ClaimsIdentity içerisindeki bilgiler (Kimlik'te yazan bilgiler)
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.GivenName, user.Name),
                        new Claim(ClaimTypes.Surname, user.Surname),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.StreetAddress, ""),
                        new Claim("OzelKey", "OzelValue")
                    };

                    if (user.Roles.Any())
                    {
                        foreach (var role in user.Roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.Name));
                        }
                    }

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
                var user = _userService.Register(model);
                if (user != null)
                {
                    return RedirectToAction("RegisterSuccess");
                }
            }

            ModelState.AddModelError(string.Empty, "Kayıt sırasında bir hata oluştu");

            return View();
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }

        public IActionResult EmailActivation(string email, string activationKey)
        {
            var isSuccess = _userService.ActivateUserByEmail(email, activationKey);
            if (isSuccess)
            {
                return RedirectToAction("EmailActivationSuccess");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult EmailActivationSuccess()
        {
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

        public async Task GoogleLogin(string? returnUrl)
        {
            string redirectUri = Url.Action("GoogleResponse", new { ReturnUrl = returnUrl });

            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = redirectUri
            });
        }

        public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (result.Succeeded)
            {
                var principal = result.Principal;
                var claims = principal.Identities.FirstOrDefault()?.Claims.ToList();
                
                var photoUrl = principal.FindFirst("urn:google:picture")?.Value;
                var emailAddress = principal.FindFirst(ClaimTypes.Email)?.Value;
                
                var isUserExist = _userService.GetAll().Any(e => e.Email == emailAddress);
                if (!isUserExist)
                {
                    var userDto = new RegisterDto
                    {
                        EmailAddress = emailAddress,
                        Name = principal.FindFirst(ClaimTypes.GivenName)?.Value,
                        Surname = principal.FindFirst(ClaimTypes.Surname)?.Value,
                        Password = Guid.NewGuid().ToString(),
                    };
                    
                    var registeredUser = _userService.Register(userDto);

                    if (registeredUser != null)
                    {
                        await LoginWithClaims(emailAddress, claims);
                        
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    await LoginWithClaims(emailAddress, claims);
                }

                return Redirect(returnUrl);
            }

            return RedirectToAction("Login");
        }

        private async Task LoginWithClaims(string? emailAddress, List<Claim>? claims)
        {
            var activeUser = _userService.GetByEmail(emailAddress);
            if (activeUser != null)
            {
                if (activeUser.Roles.Any())
                {
                    foreach (var role in activeUser.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddDays(30)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimsPrinciple,
                        authProperties
                    );
                }
            }
        }
    }
}
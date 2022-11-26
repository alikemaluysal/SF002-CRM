using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
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
    }
}

using Company.Crm.Application.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers
{
    //[Authorize(Roles = RoleNameConsts.Administrator + "," + RoleNameConsts.SalesManager)]
    [Authorize(Roles = RoleNameConsts.SalesManager)]
    [Area("Admin")]
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

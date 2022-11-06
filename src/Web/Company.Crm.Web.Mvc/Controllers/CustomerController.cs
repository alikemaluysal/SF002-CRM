using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAll();
            return View(customers);
        }
    }
}

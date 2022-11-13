using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index(int page = 1)
        {
            var customers = _customerService.GetPaged(page);
            return View(customers);
        }

        public IActionResult Save(CreateOrUpdateCustomerDto dto)
        {
            var result = _customerService.Insert(dto);
            return RedirectToAction("Index");
        }
    }
}

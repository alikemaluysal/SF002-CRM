using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public List<CustomerDto> Get()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _customerService.GetCustomerById(id);

            return Ok(data);
        }
    }
}

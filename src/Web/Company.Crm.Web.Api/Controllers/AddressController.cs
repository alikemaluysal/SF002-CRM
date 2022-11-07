using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var address = _service.GetAll();
            return Ok(address);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var address = _service.GetById(id);
            return Ok(address);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            var isAdded = _service.Insert(address);
            return Ok(isAdded);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Address address)
        {
            var isUpdated = _service.Update(address);
            return Ok(isUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _service.DeleteById(id);
            return Ok(isDeleted);
        }

        public IActionResult Delete([FromBody]Address entity)
        {
            var isDeleted = _service.Delete(entity);
            return Ok(isDeleted);
        }
    }
}

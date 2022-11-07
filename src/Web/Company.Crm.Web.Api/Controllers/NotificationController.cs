using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;
        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _service.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Notification entity)
        {
            var data = _service.Insert(entity);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Notification entity)
        {
            var data = _service.Update(entity);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _service.DeleteById(id);
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Notification entity)
        {
            var data = _service.Delete(entity);
            return Ok(data);
        }
    }
}

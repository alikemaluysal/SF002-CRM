using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task = Company.Crm.Domain.Entities.Task;
namespace Company.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var task = _service.GetAll();
            return Ok(task);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = _service.GetById(id);
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Task task)
        {
            var isAdded = _service.Insert(task);
            return Ok(isAdded);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Task task)
        {
            var isUpdated = _service.Update(task);
            return Ok(isUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _service.DeleteById(id);
            return Ok(isDeleted);
        }

        public IActionResult Delete([FromBody] Task entity)
        {
            var isDeleted = _service.Delete(entity);
            return Ok(isDeleted);
        }
    }
}


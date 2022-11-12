using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Task = Company.Crm.Domain.Entities.Task;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var task = _taskService.GetAll();
        return Ok(task);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var task = _taskService.GetById(id);
        return Ok(task);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Task task)
    {
        var isAdded = _taskService.Insert(task);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Task task)
    {
        var isUpdated = _taskService.Update(task);
        return Ok(isUpdated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _taskService.DeleteById(id);
        return Ok(isDeleted);
    }

    [HttpPost("deleteByEntity")]
    public IActionResult Delete([FromBody] Task entity)
    {
        var isDeleted = _taskService.Delete(entity);
        return Ok(isDeleted);
    }
}
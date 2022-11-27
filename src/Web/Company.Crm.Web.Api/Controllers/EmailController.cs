using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IPersonEmailService _service;

    public EmailController(IPersonEmailService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var email = _service.GetAll();
        return Ok(email);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var email = _service.GetById(id);
        return Ok(email);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Email email)
    {
        var isAdded = _service.Insert(email);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Email email)
    {
        var isUpdated = _service.Update(email);
        return Ok(isUpdated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _service.DeleteById(id);
        return Ok(isDeleted);
    }

    public IActionResult Delete([FromBody] Email entity)
    {
        var isDeleted = _service.Delete(entity);
        return Ok(isDeleted);
    }
}
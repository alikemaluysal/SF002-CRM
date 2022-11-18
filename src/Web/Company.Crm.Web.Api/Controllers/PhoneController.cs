using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhoneController : ControllerBase
{
    private readonly IPhoneService _service;

    public PhoneController(IPhoneService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var phone = _service.GetAll();
        return Ok(phone);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var phone = _service.GetById(id);
        return Ok(phone);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Phone phone)
    {
        var isAdded = _service.Insert(phone);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Phone phone)
    {
        var isUpdated = _service.Update(phone);
        return Ok(isUpdated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _service.DeleteById(id);
        return Ok(isDeleted);
    }

    public IActionResult Delete([FromBody] Phone entity)
    {
        var isDeleted = _service.Delete(entity);
        return Ok(isDeleted);
    }
}
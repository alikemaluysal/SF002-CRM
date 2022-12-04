using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserPhoneController : ControllerBase
{
    private readonly IUserPhoneService _service;

    public UserPhoneController(IUserPhoneService service)
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
    public IActionResult Post([FromBody] UserPhone userPhone)
    {
        var isAdded = _service.Insert(userPhone);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UserPhone userPhone)
    {
        var isUpdated = _service.Update(userPhone);
        return Ok(isUpdated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _service.DeleteById(id);
        return Ok(isDeleted);
    }

    public IActionResult Delete([FromBody] UserPhone entity)
    {
        var isDeleted = _service.Delete(entity);
        return Ok(isDeleted);
    }
}
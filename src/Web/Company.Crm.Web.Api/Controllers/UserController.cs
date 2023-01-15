using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities.Usr;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _userService.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var data = _userService.GetById(id);
        return Ok(data);
    }

    [HttpPost]
    public IActionResult Insert([FromBody] User user)
    {
        var isAdded = _userService.Insert(user);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] User userStatus)
    {
        var isUpdated = _userService.Update(userStatus);
        return Ok(isUpdated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _userService.DeleteById(id);
        return Ok(isDeleted);
    }

    [HttpPost("deleteByEntity")]
    public IActionResult DeleteById([FromBody] User user)
    {
        var isDeleted = _userService.Delete(user);
        return Ok(isDeleted);
    }
}
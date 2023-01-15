using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Company.Framework.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Authorize]
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
    public IActionResult Get()
    {
        var data = _customerService.GetAll();
        return Ok(data);
    }

    [HttpGet("GetPaged")]
    public IActionResult GetPaged([FromQuery] PaginationRequest req)
    {
        var customers = _customerService.GetPaged(req);

        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var data = _customerService.GetById(id);
        return Ok(data);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateOrUpdateCustomerDto dto)
    {
        var data = _customerService.Insert(dto);
        return Ok(data);
    }

    [HttpPatch("{id}")]
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CreateOrUpdateCustomerDto dto)
    {
        var data = _customerService.Update(dto);
        return Ok(data);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var data = _customerService.DeleteById(id);
        return Ok(data);
    }
}
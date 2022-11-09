using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var address = _addressService.GetAll();
        return Ok(address);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var address = _addressService.GetById(id);
        return Ok(address);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Address address)
    {
        var isAdded = _addressService.Insert(address);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Address address)
    {
        var isUpdated = _addressService.Update(address);
        return Ok(isUpdated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _addressService.DeleteById(id);
        return Ok(isDeleted);
    }

    public IActionResult Delete([FromBody] Address entity)
    {
        var isDeleted = _addressService.Delete(entity);
        return Ok(isDeleted);
    }
}
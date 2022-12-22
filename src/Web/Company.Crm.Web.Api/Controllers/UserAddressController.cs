using Company.Crm.Application.Dtos.Address;
using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAddressController : ControllerBase
{
    private readonly IUserAddressService _addressService;

    public UserAddressController(IUserAddressService addressService)
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
    public IActionResult Post([FromBody] AddressCreateOrUpdateDto address)
    {
        var isAdded = _addressService.Insert(address);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AddressCreateOrUpdateDto address)
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

    [HttpPost("deleteByEntity")]
    public IActionResult Delete([FromBody] AddressDetailDto address)
    {
        var isDeleted = _addressService.Delete(address);
        return Ok(isDeleted);
    }
}
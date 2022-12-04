using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities.Lst;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly IRegionService _service;

    public RegionController(IRegionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var region = _service.GetAll();
        return Ok(region);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var region = _service.GetById(id);
        return Ok(region);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Region region)
    {
        var isAdded = _service.Insert(region);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Region region)
    {
        var isUpdated = _service.Update(region);
        return Ok(isUpdated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _service.DeleteById(id);
        return Ok(isDeleted);
    }

    [HttpPost("deleteByEntity")]
    public IActionResult Delete([FromBody] Region entity)
    {
        var isDeleted = _service.Delete(entity);
        return Ok(isDeleted);
    }
}
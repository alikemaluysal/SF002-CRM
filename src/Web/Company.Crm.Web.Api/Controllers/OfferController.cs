using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferController : ControllerBase
{
    private readonly IOfferService _service;

    public OfferController(IOfferService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var data = _service.GetAll();
        return Ok(data);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var offer = _service.GetById(id);
        return Ok(offer);
    }

    [HttpPost]
    public IActionResult Post([FromBody] OfferDto offers)
    {
        var isAdded = _service.Insert(offers);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] OfferDto offers)
    {
        var isUpdated = _service.Update(offers);
        return Ok(isUpdated);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _service.DeleteById(id);
        return Ok(isDeleted);
    }

    public IActionResult Delete([FromBody]OfferDto entity)
    {
        var isDeleted = _service.Delete(entity);
        return Ok(isDeleted);
    }
}
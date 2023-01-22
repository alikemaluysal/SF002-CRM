using Company.Crm.Application.Dtos.Notification;
using Company.Crm.Application.Dtos.Request;
using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

public class RequestController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var data = _requestService.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var request = _requestService.GetForEditById(id);
        return Ok(request);
    }

    [HttpPost]
    public IActionResult Post([FromBody] RequestCreateOrUpdateDto requests)
    {
        var isAdded = _requestService.Insert(requests);
        return Ok(isAdded);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RequestCreateOrUpdateDto requests)
    {
        var isUpdated = _requestService.Update(requests);
        return Ok(isUpdated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _requestService.DeleteById(id);
        return Ok(isDeleted);
    }

    [HttpPost("deleteByEntity")]
    public IActionResult Delete([FromBody] RequestDto entity)
    {
        var isDeleted = _requestService.Delete(entity);
        return Ok(isDeleted);
    }
}
﻿using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var data = _notificationService.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var data = _notificationService.GetById(id);
        return Ok(data);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Notification entity)
    {
        var data = _notificationService.Insert(entity);
        return Ok(data);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Notification entity)
    {
        var data = _notificationService.Update(entity);
        return Ok(data);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var data = _notificationService.DeleteById(id);
        return Ok(data);
    }

    [HttpDelete]
    public IActionResult Delete([FromBody] Notification entity)
    {
        var data = _notificationService.Delete(entity);
        return Ok(data);
    }
}
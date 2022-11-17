﻿using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Company.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _service;

        public TitleController(ITitleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var title = _service.GetAll();
            return Ok(title);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var title = _service.GetById(id);
            return Ok(title);
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Title titles)
        {
            var isAdded = _service.Insert(titles);
            return Ok(isAdded);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Title titles)
        {
            var isUpdated = _service.Update(titles);
            return Ok(isUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var isDeleted = _service.DeleteById(id);
            return Ok(isDeleted);
        }
        
    }
}
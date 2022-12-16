﻿using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _saleService.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _saleService.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sale entity)
        {
            var data = _saleService.Insert(entity);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Sale entity)
        {
            var data = _saleService.Update(entity);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _saleService.DeleteById(id);
            return Ok(data);
        }

        [HttpPost("deleteByEntity")]
        public IActionResult Delete([FromBody] Sale entity)
        {
            var data = _saleService.Delete(entity);
            return Ok(data);
        }
    }
}
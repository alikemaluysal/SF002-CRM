using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferStatusController : ControllerBase
    {
        private readonly IOfferStatusService _offerStatusService;

        public OfferStatusController(IOfferStatusService offerStatusService)
        {
            _offerStatusService = offerStatusService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _offerStatusService.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _offerStatusService.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] OfferStatus offerStatus)
        {
            var isAdded = _offerStatusService.Insert(offerStatus);
            return Ok(isAdded);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OfferStatus offerStatus)
        {
            var isUpdated = _offerStatusService.Update(offerStatus);
            return Ok(isUpdated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _offerStatusService.DeleteById(id);
            return Ok(isDeleted);
        }

        [HttpPost("deleteByEntity")]
        public IActionResult DeleteById([FromBody] OfferStatus offerStatus)
        {
            var isDeleted = _offerStatusService.Delete(offerStatus);
            return Ok(isDeleted);
        }
    }
}

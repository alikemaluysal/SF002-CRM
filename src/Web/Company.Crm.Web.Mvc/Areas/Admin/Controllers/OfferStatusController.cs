using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class OfferStatusController : Controller
    {
        private readonly IOfferStatusService _ofService;

        public OfferStatusController(IOfferStatusService ofService)
        {
            _ofService = ofService;
        }

        public IActionResult Index(int page = 1)
        {
            var OfferStatus=_ofService.GetPaged(page);
            return View(OfferStatus);
        }


        public async Task<PartialViewResult>Detail(int id)
        {
            var data = _ofService.GetById(id);
            return PartialView("_Detail", data);

        }

        [HttpGet]

        public PartialViewResult Create()
        {
            var data = new OfferStatus();

            return PartialView("_Create", data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult>Create(OfferStatus offerStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var IsInserted = _ofService.Insert(offerStatus);
                    if (IsInserted)
                    {
                        return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
                    }
                }
            }
            catch
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }

            return PartialView("_Create", offerStatus);
        }


        public async Task<ActionResult>Edit(OfferStatus offerStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var IsUpdated = _ofService.Update(offerStatus);
                    if (IsUpdated)
                    {
                        return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
                    }
                }
            }
            catch 
            {
                ModelState.AddModelError("", "Unable to save changes.");
               
            }

            return PartialView("_Edit", offerStatus);
        }


        [HttpGet]
        public async Task<PartialViewResult> Delete(int id)
        {
            var data = _ofService.GetById(id);

            return PartialView ("_Delete", data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            
             return Json(new { IsSuccess = _ofService.DeleteById(id), Redirect = Url.Action("Index") });
        }













    }
}

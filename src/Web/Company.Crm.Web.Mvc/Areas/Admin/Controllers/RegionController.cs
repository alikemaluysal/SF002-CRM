using Company.Crm.Application.Dtos.Notification;
using Company.Crm.Application.Services;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Entities.Lst;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        public IActionResult Index(int page = 1)
        {
            var Region = _regionService.GetPaged(page);
            return View(Region);
        }


        public async Task<PartialViewResult> Detail(int id)
        {
            var data = _regionService.GetById(id);
            return PartialView("_Detail", data);

        }

        [HttpGet]

        public PartialViewResult Create()
        {
            var data = new Region();

            return PartialView("_Create", data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Region region)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var IsInserted = _regionService.Insert(region);
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

            return PartialView("_Create", region);
        }


        [HttpGet]
        public async Task<PartialViewResult> Edit(int? id)
        {
            var region = new Region();
            if (id.HasValue)
            {
                region = _regionService.GetForEditById(id.Value);
            }
            return PartialView("_Edit", region);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Region region)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var isUpdated = _regionService.Update(region);
                    if (isUpdated)
                        return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return PartialView("_Edit", region);
        }



        [HttpGet]
        public async Task<PartialViewResult> Delete(int id)
        {
            var data = _regionService.GetById(id);

            return PartialView("_Delete", data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            return Json(new { IsSuccess = _regionService.DeleteById(id), Redirect = Url.Action("Index") });
        }




    }

}

using Company.Crm.Application.Constants;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities.Lst;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers;

[Authorize(Roles = RoleNameConsts.Administrator)]
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
        var regions = _regionService.GetPaged(page);
        return View(regions);
    }

    public async Task<PartialViewResult> Detail(int id)
    {
        var region = _regionService.GetById(id);
        return PartialView("_Detail", region);
    }

    [HttpGet]
    public PartialViewResult Create()
    {
        var region = new Region();

        return PartialView("_Create", region);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Region region)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var isInserted = _regionService.Insert(region);
                if (isInserted)
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
        var region = _regionService.GetById(id);

        return PartialView("_Delete", region);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        return Json(new { IsSuccess = _regionService.DeleteById(id), Redirect = Url.Action("Index") });
    }
}
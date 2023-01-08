using Company.Crm.Application.Constants;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Entities.Lst;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers;

[Authorize(Roles = RoleNameConsts.Administrator)]
[Area("Admin")]
public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public IActionResult Index(int page = 1)
    {
        var departments = _departmentService.GetPaged(page);
        return View(departments);
    }

    public async Task<PartialViewResult> Detail(int id)
    {
        var department = _departmentService.GetById(id);
        return PartialView("_Detail", department);
    }

    [HttpGet]
    public PartialViewResult Create()
    {
        var department = new Department();

        return PartialView("_Create", department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Department department)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var isInserted = _departmentService.Insert(department);
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

        return PartialView("_Create", department);
    }

    [HttpGet]
    public async Task<PartialViewResult> Edit(int? id)
    {
        var department = new Department();
        if (id.HasValue)
        {
            department = _departmentService.GetForEditById(id.Value);
        }
        return PartialView("_Edit", department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Department department)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var isUpdated = _departmentService.Update(department);
                if (isUpdated)
                    return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
            }
        }
        catch
        {
            ModelState.AddModelError("", "Unable to save changes.");
        }
        return PartialView("_Edit", department);
    }

    [HttpGet]
    public async Task<PartialViewResult> Delete(int id)
    {
        var department = _departmentService.GetById(id);

        return PartialView("_Delete", department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        return Json(new { IsSuccess = _departmentService.DeleteById(id), Redirect = Url.Action("Index") });
    }
}
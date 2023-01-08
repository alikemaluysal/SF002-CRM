using Company.Crm.Application.Constants;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities.Lst;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskStatus = Company.Crm.Domain.Entities.Lst.TaskStatus;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers;

[Authorize(Roles = RoleNameConsts.Administrator)]
[Area("Admin")]
public class TaskStatusController : Controller
{
    private readonly ITaskStatusService _taskStatusService;

    public TaskStatusController(ITaskStatusService taskStatusService)
    {
        _taskStatusService = taskStatusService;
    }

    public IActionResult Index(int page = 1)
    {
        var taskstatus = _taskStatusService.GetPaged(page);
        return View(taskstatus);
    }

    public async Task<PartialViewResult> Detail(int id)
    {
        var taskstatus = _taskStatusService.GetById(id);
        return PartialView("_Detail", taskstatus);
    }

    [HttpGet]
    public PartialViewResult Create()
    {
        var taskstatus = new TaskStatus();

        return PartialView("_Create", taskstatus);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(TaskStatus taskStatus)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var isInserted = _taskStatusService.Insert(taskStatus);
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

        return PartialView("_Create", taskStatus);
    }

    [HttpGet]
    public async Task<PartialViewResult> Edit(int? id)
    {
        var taskstatus = new TaskStatus();
        if (id.HasValue)
        {
            taskstatus = _taskStatusService.GetForEditById(id.Value);
        }
        return PartialView("_Edit", taskstatus);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(TaskStatus taskstatus)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var isUpdated = _taskStatusService.Update(taskstatus);
                if (isUpdated)
                    return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
            }
        }
        catch
        {
            ModelState.AddModelError("", "Unable to save changes.");
        }
        return PartialView("_Edit", taskstatus);
    }

    [HttpGet]
    public async Task<PartialViewResult> Delete(int id)
    {
        var taskstatus = _taskStatusService.GetById(id);

        return PartialView("_Delete", taskstatus);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        return Json(new { IsSuccess = _taskStatusService.DeleteById(id), Redirect = Url.Action("Index") });
    }
}
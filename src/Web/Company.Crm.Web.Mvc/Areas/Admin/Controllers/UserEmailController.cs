using Company.Crm.Application.Dtos.UserEmail;
using Company.Crm.Application.Dtos.UserPhone;
using Company.Crm.Application.Services;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Application.Validators;
using Company.Crm.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers;

public class UserEmailController : Controller
{
    private readonly IUserEmailService _userEmailService;
    private readonly IValidator<CreateOrUpdateUserEmailDto> _userEmailValidator;

    public UserEmailController(IUserEmailService userEmailService, IValidator<CreateOrUpdateUserEmailDto> userEmailValidator)
    {
        _userEmailService = userEmailService;
        _userEmailValidator = userEmailValidator;
    }

    public IActionResult Index(int page = 1)
    {
        var userEmail = _userEmailService.GetPaged(page);
        return View(userEmail);
    }

    public async Task<PartialViewResult> Detail(int id)
    {
        var userPhone = _userEmailService.GetById(id);
        return PartialView("_Detail", userPhone);
    }

    [HttpGet]
    public PartialViewResult Create()
    {
        var dto = new CreateOrUpdateUserEmailDto();
        return PartialView("_Create", dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateOrUpdateUserEmailDto dto)
    {
        try
        {
            var validationResult = _userEmailValidator.Validate(dto);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);

                return PartialView("_Create", dto);
            }


            if (validationResult.IsValid)
            {
                var isInserted = _userEmailService.Insert(dto);
                if (isInserted)
                    return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
            }
        }
        catch
        {
            ModelState.AddModelError("", "Unable to save changes.");
        }

        return PartialView("_Create", dto);
    }

    public async Task<PartialViewResult> Edit(int? id)
    {
        var dto = new CreateOrUpdateUserEmailDto();
        if (id.HasValue) dto = _userEmailService.GetForEditById(id.Value);

        return PartialView("_Edit", dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(UserEmail entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var isUpdated = _userEmailService.Update(entity);
                if (isUpdated)
                    return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
            }
        }
        catch
        {
            ModelState.AddModelError("", "Unable to save changes.");
        }

        return PartialView("_Edit", entity);
    }

    [HttpGet]
    public async Task<PartialViewResult> Delete(int id)
    {
        var serviceItem = _userEmailService.GetById(id);

        return PartialView("_Delete", serviceItem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        _userEmailService.DeleteById(id);
        return RedirectToAction(nameof(Index));
    }
}
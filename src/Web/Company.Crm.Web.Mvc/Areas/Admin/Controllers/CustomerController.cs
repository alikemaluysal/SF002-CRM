using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
public class CustomerController : Controller
{
	private readonly ICustomerService _customerService;
	private readonly IStatusTypeService _statusTypeService;

	public CustomerController(ICustomerService customerService, IStatusTypeService statusTypeService)
	{
		_customerService = customerService;
		_statusTypeService = statusTypeService;
	}

	public IActionResult Index(int page = 1)
	{
		var customers = _customerService.GetPaged(page);
		return View(customers);
	}

	public async Task<PartialViewResult> Detail(int id)
	{
		var customer = _customerService.GetById(id);
		return PartialView("_Detail", customer);
	}

	[HttpGet]
	public PartialViewResult Create()
	{
		var dto = new CreateOrUpdateCustomerDto();

		//item.Genders = _genderService.GetAll().Select(e=> new SelectListItem { Value = e.Id, Text = e.Name });

		FillDropdownItems(dto);

		return PartialView("_Create", dto);
	}

	private void FillDropdownItems(CreateOrUpdateCustomerDto dto)
	{
		dto.Genders = new List<SelectListItem>
		{
			new SelectListItem { Value = "1", Text = "Erkek" },
			new SelectListItem { Value = "2", Text = "Kadın" },
		};

		dto.Titles = new List<SelectListItem>
		{
			new SelectListItem { Value = "1", Text = "Mühendis" },
			new SelectListItem { Value = "2", Text = "Yazılım Geliştirici" },
		};

		dto.StatusTypes = _statusTypeService.GetAll()
			.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> Create(CreateOrUpdateCustomerDto item)
	{
		try
		{
			if (ModelState.IsValid)
			{
				var isInserted = _customerService.Insert(item);
				if (isInserted)
					return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
			}
		}
		catch
		{
			ModelState.AddModelError("", "Unable to save changes.");
		}

		FillDropdownItems(item);

		return PartialView("_Create", item);
	}

	public async Task<PartialViewResult> Edit(int? id)
	{
		var dto = new CreateOrUpdateCustomerDto();
		if (id.HasValue)
		{
			dto = _customerService.GetForEditById(id.Value);
		}

		FillDropdownItems(dto);

		return PartialView("_Edit", dto);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> Edit(CreateOrUpdateCustomerDto dto)
	{
		try
		{
			if (ModelState.IsValid)
			{
				var isUpdated = _customerService.Update(dto);
				if (isUpdated)
					return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
			}
		}
		catch
		{
			ModelState.AddModelError("", "Unable to save changes.");
		}

		FillDropdownItems(dto);

		return PartialView("_Edit", dto);
	}

	[HttpGet]
	public async Task<PartialViewResult> Delete(int id)
	{
		var serviceItem = _customerService.GetById(id);

		return PartialView("_Delete", serviceItem);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> DeleteConfirmed(int id)
	{
		_customerService.DeleteById(id);
		return RedirectToAction(nameof(Index));
	}
}
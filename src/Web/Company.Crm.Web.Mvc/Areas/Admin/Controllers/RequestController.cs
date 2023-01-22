using Company.Crm.Application.Constants;
using Company.Crm.Application.Dtos;
using Company.Crm.Application.Dtos.Notification;
using Company.Crm.Application.Services.Abstracts;
using Company.Framework.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        private readonly IValidator<RequestCreateOrUpdateDto> _requestValidator;
        private readonly IStatusTypeService _statusTypeService;


        public RequestController(IRequestService requestService, IStatusTypeService statusTypeService,IValidator<RequestCreateOrUpdateDto> requestValidator)
        {
            _requestService = requestService;
            _statusTypeService = statusTypeService;
            _requestValidator = requestValidator;
        }

        public IActionResult Index(int page = 1)
        {
            var requests = _requestService.GetPaged(page);
            return View(requests);

        }

        public async Task<PartialViewResult> Detail(int id)
        {
            var request = _requestService.GetForEditById(id);
            return PartialView("_Detail", request);
        }

        public PartialViewResult Create()
        {
            var dto = new RequestCreateOrUpdateDto();
            
            return PartialView("_Create", dto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RequestCreateOrUpdateDto item)
        {
            try
            {
                //var validationResult = new requestValidator().Validate(item);
                var validationResult = _requestValidator.Validate(item);

                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(ModelState);

                    return PartialView("_Create", item);
                }

                //if (ModelState.IsValid)
                if (validationResult.IsValid)
                {
                    var isInserted = _requestService.Insert(item);
                    if ((bool)isInserted)
                        return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

         

            return PartialView("_Create", item);
        }

        public async Task<PartialViewResult> Edit(int? id)
        {

            var dto = new RequestCreateOrUpdateDto();
            if (id.HasValue) dto = _requestService.GetForEditById(id.Value);

         

            return PartialView("_Edit", dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RequestCreateOrUpdateDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUpdated = _requestService.Update(dto);
                    if (isUpdated) return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }

            return PartialView("_Edit", dto);
        }


        [HttpGet]
        public async Task<PartialViewResult> Delete(int id)
        {
            var data = _requestService.GetForEditById(id);
            return PartialView("_Delete", data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            return Json(new { IsSuccess = _requestService.DeleteById(id), Redirect = Url.Action("Index") });
        }
    }
}

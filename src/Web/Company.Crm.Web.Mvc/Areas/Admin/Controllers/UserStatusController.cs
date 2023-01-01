using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities.Lst;
using Microsoft.AspNetCore.Mvc;

namespace Company.Crm.Web.Mvc.Areas.Admin.Controllers
{
    public class UserStatusController : Controller
    {
        private readonly IUserStatusService _UsService;

        public UserStatusController(IUserStatusService usService)
        {
            _UsService = usService;
        }

        public IActionResult Index()
        {
            var data = _UsService.GetAll().ToList();
            return View(data);
        }

        public async Task<PartialViewResult> Detail(int id)
        {
            var data = _UsService.GetById(id);
            return PartialView("_Detail", data);
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            var data = new UserStatus();

            return PartialView("_Create", data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserStatus userStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _UsService.Insert(userStatus);
                    if (data)
                    {
                        return Json(new { IsSuccess = true, Redirect = Url.Action("Index") });
                    }
                }
            }
            catch
            {

                ModelState.AddModelError("", "Unable to save changes");
            }

            return PartialView("_Create", userStatus);
        }


        [HttpGet]
        public async Task<PartialViewResult> Edit(int? id)
        {
            var model = new UserStatus();
            if (id.HasValue) model = _UsService.GetById(id.Value);

            return PartialView("_Edit", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(UserStatus userStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var İsUpdate = _UsService.Update(userStatus);
                    if (İsUpdate)
                    {
                        return Json(new { IsSucces = true, Redirect = Url.Action("Index") });
                    }
                }
            }
            catch
            {

                ModelState.AddModelError("", "Unable to save changes.");
            }

            return PartialView("_Edit", userStatus);
        }

        [HttpGet]
        public async Task<PartialViewResult> Delete(int id)
        {
            var data = _UsService.GetById(id);
            return PartialView("_Delete", data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            return Json(new { IsSuccess = _UsService.DeleteById(id), Redirect = Url.Action("Index") });
        }

    }
}

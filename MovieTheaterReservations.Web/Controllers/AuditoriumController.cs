using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservations.DisplayModels.Auditorium;
using MovieTheaterReservations.Services.Services.AuditoriumService;
using System.Security.Claims;

namespace MovieTheaterReservations.Web.Controllers
{
    [Authorize]
    public class AuditoriumController : Controller
    {
        private readonly IAuditoriumService _auditoriumService;
        private readonly UserManager<IdentityUser> _userManager;
        
        public AuditoriumController(IAuditoriumService auditoriumService, UserManager<IdentityUser> userManager)
        {
            _auditoriumService = auditoriumService;
            _userManager = userManager;
        }
        // GET: AuditoriumController
        public ActionResult Index()
        {
            var result = _auditoriumService.GetAllAuditoriums();
            return View(result);
        }

        // GET: AuditoriumController/Details/5
        public ActionResult Details(int id)
        {
            var result = _auditoriumService.GetAuditoriumById(id);
            return View(result);
        }

        // GET: AuditoriumController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: AuditoriumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuditoriumCreate auditoriumCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(auditoriumCreate);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_auditoriumService.CreateAuditorium(auditoriumCreate, userId))
            {
                TempData["SaveResult"] = "Auditorium was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Auditorium could not be created");
            return View(auditoriumCreate);
        }

        // GET: AuditoriumController/Edit/5
        public ActionResult Edit(int id)
        {
            var detail = _auditoriumService.GetAuditoriumById(id);
            var model = new AuditoriumEdit()
            {
                Id = id,
                Name = detail.Name,
            };
            return View(model);
        }

        // POST: AuditoriumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuditoriumEdit auditoriumEdit)
        {
            if (!ModelState.IsValid) return View(auditoriumEdit);

            if (auditoriumEdit.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(auditoriumEdit);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(_auditoriumService.UpdateAuditorium(auditoriumEdit, userId))
            {
                TempData["SaveResult"] = "Auditorium was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Auditorium could not be updated");
            return View(auditoriumEdit);
        }

        // GET: AuditoriumController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _auditoriumService.GetAuditoriumById(id);
            return View(model);
        }

        // POST: AuditoriumController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAuditorium(int id)
        {
            _auditoriumService.DeleteAuditorium(id);
            TempData["SaveResult"] = "Auditorium was deleted";
            return RedirectToAction("Index");
        }
    }
}

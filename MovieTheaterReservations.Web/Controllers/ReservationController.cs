using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservations.DisplayModels.Reservation;
using MovieTheaterReservations.Services.Services.ReservationService;
using System.Security.Claims;

namespace MovieTheaterReservations.Web.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<IdentityUser> _userManager;

        public ReservationController(IReservationService reservationService, UserManager<IdentityUser> userManager)
        {
            _reservationService = reservationService;
            _userManager = userManager;
        }
        // GET: AuditoriumController
        public ActionResult Index()
        {
            var result = _reservationService.GetAllReservations();
            return View(result);
        }

        // GET: AuditoriumController/Details/5
        public ActionResult Details(int id)
        {
            var result = _reservationService.GetReservation(id);
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
        public ActionResult Create(ReservationCreate reservationCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(reservationCreate);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_reservationService.CreateReservation(reservationCreate, userId))
            {
                TempData["SaveResult"] = "Reservation was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Reservation could not be created");
            return View(reservationCreate);
        }

        // GET: AuditoriumController/Edit/5
        public ActionResult Edit(int id)
        {
            var detail =_reservationService.GetReservation(id);
            var model = new ReservationEdit()
            {
                ReservationId = id,
                MovieShowingId = detail.MovieShowingId,
                ReservationType = detail.ReservationType,
                ReservationContactType = detail.ReservationContactType
            };
            return View(model);
        }

        // POST: AuditoriumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReservationEdit reservationEdit)
        {
            if (!ModelState.IsValid) return View(reservationEdit);

            if (reservationEdit.ReservationId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(reservationEdit);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_reservationService.UpdateReservation(reservationEdit, userId))
            {
                TempData["SaveResult"] = "Reservation was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "REservation could not be updated");
            return View(reservationEdit);
        }

        // GET: AuditoriumController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _reservationService.GetReservation(id);
            return View(model);
        }

        // POST: AuditoriumController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReservation(int id)
        {
            _reservationService.DeleteReservation(id);
            TempData["SaveResult"] = "Reservation was deleted";
            return RedirectToAction("Index");
        }
    }
}

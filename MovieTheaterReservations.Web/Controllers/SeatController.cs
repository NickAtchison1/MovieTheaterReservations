using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservations.DisplayModels.Seat;
using MovieTheaterReservations.Services.Services.SeatService;
using System.Security.Claims;

namespace MovieTheaterReservations.Web.Controllers
{
    [Authorize]
    public class SeatController : Controller
    {
        private readonly ISeatService _seatService;
        private readonly UserManager<IdentityUser> _userManager;

        public SeatController(ISeatService seatService, UserManager<IdentityUser> userManager)
        {
            _seatService = seatService;
            _userManager = userManager;
        }
        // GET: AuditoriumController
        public ActionResult Index()
        {
            var result = _seatService.GetSeats();
            return View(result);
        }

        // GET: AuditoriumController/Details/5
        public ActionResult Details(int id)
        {
            var result = _seatService.GetSeatById(id);
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
        public ActionResult Create(SeatCreate seatCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(seatCreate);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_seatService.CreateSeat(seatCreate, userId))
            {
                TempData["SaveResult"] = "Seat was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Seat could not be created");
            return View(seatCreate);
        }

        // GET: AuditoriumController/Edit/5
        public ActionResult Edit(int id)
        {
            var detail = _seatService.GetSeatById(id);
            var model = new SeatEdit()
            {
                SeatId = id,
                Row = detail.Row,
                SeatNumber = detail.SeatNumber,
                SeatType = detail.SeatType,
                AuditoriumId = detail.AuditoriumId
            };
            return View(model);
        }

        // POST: AuditoriumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SeatEdit seatEdit)
        {
            if (!ModelState.IsValid) return View(seatEdit);

            if (seatEdit.SeatId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(seatEdit);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_seatService.UpdateSeat(seatEdit, userId))
            {
                TempData["SaveResult"] = "Seat was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Seat could not be updated");
            return View(seatEdit);
        }

        // GET: AuditoriumController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _seatService.GetSeatById(id);
            return View(model);
        }

        // POST: AuditoriumController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSeat(int id)
        {
            _seatService.DeleteSeat(id);
            TempData["SaveResult"] = "Seat was deleted";
            return RedirectToAction("Index");
        }
    }
}

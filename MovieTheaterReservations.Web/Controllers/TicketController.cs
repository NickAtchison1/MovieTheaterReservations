using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservations.DisplayModels.Ticket;
using MovieTheaterReservations.Services.Services.TicketService;
using System.Security.Claims;

namespace MovieTheaterReservations.Web.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly UserManager<IdentityUser> _userManager;

        public TicketController(ITicketService ticketService, UserManager<IdentityUser> userManager)
        {
            _ticketService = ticketService;
            _userManager = userManager;
        }
        // GET: AuditoriumController
        public ActionResult Index()
        {
            var result = _ticketService.GetAllTickets();
            return View(result);
        }

        // GET: AuditoriumController/Details/5
        public ActionResult Details(int id)
        {
            var result = _ticketService.GetTicket(id);
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
        public ActionResult Create(TicketCreate ticketCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(ticketCreate);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_ticketService.CreateTicket(ticketCreate, userId))
            {
                TempData["SaveResult"] = "Ticket was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Ticket could not be created");
            return View(ticketCreate);
        }

        // GET: AuditoriumController/Edit/5
        public ActionResult Edit(int id)
        {
            var detail = _ticketService.GetTicket(id);
            var model = new TicketEdit()
            {
                TicketId = id,
                MovieShowingId = detail.MovieShowingId,
                SeatId = detail.SeatId,
               
                TicketPrice = detail.TicketPrice,
                TicketType = detail.TicketType,
                ShowingType = detail.ShowingType
            };
            return View(model);
        }

        // POST: AuditoriumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TicketEdit ticketEdit)
        {
            if (!ModelState.IsValid) return View(ticketEdit);

            if (ticketEdit.TicketId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(ticketEdit);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_ticketService.UpdateTicket(ticketEdit, userId))
            {
                TempData["SaveResult"] = "Ticket was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ticket could not be updated");
            return View(ticketEdit);
        }

        // GET: AuditoriumController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _ticketService.GetTicket(id);
            return View(model);
        }

        // POST: AuditoriumController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTicket(int id)
        {
            _ticketService.DeleteTicket(id);
            TempData["SaveResult"] = "Ticket was deleted";
            return RedirectToAction("Index");
        }
    }
}

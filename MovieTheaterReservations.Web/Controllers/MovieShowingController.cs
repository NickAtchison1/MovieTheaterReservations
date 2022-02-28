using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservations.Models.DisplayModels.MovieShowing;
using MovieTheaterReservations.Services.Services.MovieShowingService;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MovieTheaterReservations.Web.Controllers
{
    [Authorize]
    public class MovieShowingController : Controller
    {
   

        private readonly IMovieShowingService _movieShowingService;
        private readonly UserManager<IdentityUser> _userManager;

        public MovieShowingController(IMovieShowingService movieShowingService, UserManager<IdentityUser> userManager)
        {
            _movieShowingService = movieShowingService;
            _userManager = userManager;
        }
        // GET: AuditoriumController
        public ActionResult Index()
        {
            var result = _movieShowingService.GetAllMovieShowing();
            return View(result);
        }

        // GET: AuditoriumController/Details/5
        //public ActionResult Details(int id)
        //{
        //    var result = _movieShowingService.GetMovieShowing(id);
        //    return View(result);
        //}
        //[HttpGet]
        // [ActionName("Detail")]
        // [Route("MoveiShowing/MovingShowingAuditorium/{id:int}")]
        public ActionResult Details(int id)
        {
            var result = _movieShowingService.GetMovieShowingSeats(id);
            TempData["MovieShowing"] = JsonConvert.SerializeObject(result);
            TempData.Keep();
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
        public ActionResult Create(MovieShowingCreate movieShowingCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(movieShowingCreate);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_movieShowingService.CreateMovieShowing(movieShowingCreate, userId))
            {
                TempData["SaveResult"] = "Movie Showing was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Movie Showing could not be created");
            return View(movieShowingCreate);
        }

        // GET: AuditoriumController/Edit/5
        public ActionResult Edit(int id)
        {
            var detail = _movieShowingService.GetMovieShowing(id);
            var model = new MovieShowingEdit()
            {
                MovieShowingId = id,
                MovieId = detail.MovieId,
                AuditoriumId = detail.AuditoriumId,
                MovieShowingDate = detail.MovieShowingDate,
                MovieShowingTime = detail.MovieShowingTime
            };
            return View(model);
        }

        // POST: AuditoriumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieShowingEdit movieShowingEdit)
        {
            if (!ModelState.IsValid) return View(movieShowingEdit);

            if (movieShowingEdit.MovieId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(movieShowingEdit);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_movieShowingService.UpdateMovieShowing(movieShowingEdit, userId))
            {
                TempData["SaveResult"] = "Movie Showing was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Movie Showing could not be updated");
            return View(movieShowingEdit);
        }

        // GET: AuditoriumController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _movieShowingService.GetMovieShowing(id);
            return View(model);
        }

        // POST: AuditoriumController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovieShowing(int id)
        {
            _movieShowingService.DeleteMovieShowing(id);
            TempData["SaveResult"] = "Movie was deleted";
            return RedirectToAction("Index");
        }
    }
}


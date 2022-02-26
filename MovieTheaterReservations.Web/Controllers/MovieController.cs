using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservations.DisplayModels.Movie;
using MovieTheaterReservations.Models.DisplayModels.Movie;
using MovieTheaterReservations.Services.Services.MovieService;
using System.Security.Claims;

namespace MovieTheaterReservations.Web.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly UserManager<IdentityUser> _userManager;

        public MovieController(IMovieService movieService, UserManager<IdentityUser> userManager)
        {
            _movieService = movieService;
            _userManager = userManager;
        }
        // GET: AuditoriumController
        public ActionResult Index()
        {
            var result = _movieService.GetAllMovies();
            return View(result);
        }

        // GET: AuditoriumController/Details/5
        public ActionResult Details(int id)
        {
            var result = _movieService.GetMovieTodayById(id);
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
        public ActionResult Create(MovieCreate movieCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(movieCreate);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_movieService.CreateMovie(movieCreate, userId))
            {
                TempData["SaveResult"] = "Movie was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Movie could not be created");
            return View(movieCreate);
        }

        // GET: AuditoriumController/Edit/5
        public ActionResult Edit(int id)
        {
            var detail = _movieService.GetMovieTodayById(id);
            var model = new MovieEdit()
            {
                MovieId = id,
                Title = detail.Title,
                ImageUrl = detail.ImageUrl,
                Rating = detail.Rating,
                Duration = detail.Duration
            };
            return View(model);
        }

        // POST: AuditoriumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieEdit movieEdit)
        {
            if (!ModelState.IsValid) return View(movieEdit);

            if (movieEdit.MovieId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(movieEdit);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_movieService.UpdateMovie(movieEdit, userId))
            {
                TempData["SaveResult"] = "Movie was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Movie could not be updated");
            return View(movieEdit);
        }

        // GET: AuditoriumController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _movieService.GetMovieTodayById(id);
            return View(model);
        }

        // POST: AuditoriumController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovie(int id)
        {
            _movieService.DeleteMovieById(id);
            TempData["SaveResult"] = "Movie was deleted";
            return RedirectToAction("Index");
        }
    }
}

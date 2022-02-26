using Microsoft.EntityFrameworkCore;
using MovieTheaterReservations.Data.Data;
using MovieTheaterReservations.Data.Models;
using MovieTheaterReservations.DisplayModels.Movie;
using MovieTheaterReservations.Models.DisplayModels.Movie;
using MovieTheaterReservations.Models.DisplayModels.MovieShowing;

namespace MovieTheaterReservations.Services.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateMovie(MovieCreate movieCreate, string userId)
        {
            var movieEntity = new Movie()
            {
                Title = movieCreate.Title,
                ImageUrl = movieCreate.ImageUrl,
                Rating = (MovieTheaterReservations.Data.Models.Enums.Rating)movieCreate.Rating,
                //(Data.Models.Enums.Rating)(Shared.DisplayModels.Enums.Rating)movieCreate.Rating,
                Duration = movieCreate.Duration,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now

            };
            _context.Movies.Add(movieEntity);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<MovieListItem> GetAllMovies()
        {
            var query = _context.Movies
                .Select(m => new MovieListItem()
                {
                    Id = m.Id,
                    Title = m.Title,
                    ImageUrl = m.ImageUrl,
                    Rating = (MovieTheaterReservations.Models.DisplayModels.Enums.Rating)m.Rating,
                }).ToList();
            return query;
        }

        public MovieDetail GetMovieTodayById(int id)
        {
            var movieEntity = _context.Movies.Include(ms => ms.MovieShowing).Single(m => m.Id == id);
            var movieDetail = new MovieDetail()
            {
                MovieId = movieEntity.Id,
                Title = movieEntity.Title,
                ImageUrl = movieEntity.ImageUrl,
                Rating = (MovieTheaterReservations.Models.DisplayModels.Enums.Rating)movieEntity.Rating,
                Duration = movieEntity.Duration,
                ShowTimes = (List<MovieShowingTimes>)movieEntity.MovieShowing.Where(m => m.MovieShowingDate == DateTime.Today).Select(m => new MovieShowingTimes()
                {
                    MovieShowingId = m.Id,
                    MovieId = m.MovieId,
                    MovieShowingDate = m.MovieShowingDate,
                    MovieShowingTime = m.MovieShowingTime
                }).ToList(),
            };
            return movieDetail;
        }

        public bool UpdateMovie(MovieEdit movieEdit, string userId)
        {
            var movieToUpdate = _context.Movies.Single(m => m.Id == movieEdit.MovieId);
            movieToUpdate.Title = movieEdit.Title;
            movieToUpdate.ImageUrl = movieEdit.ImageUrl;
            movieToUpdate.Rating = (MovieTheaterReservations.Data.Models.Enums.Rating)movieEdit.Rating;
            movieToUpdate.Duration = movieEdit.Duration;
            movieToUpdate.CreatedBy = movieToUpdate.CreatedBy;
            movieToUpdate.CreatedDate = movieToUpdate.CreatedDate;
            movieToUpdate.UpdatedBy = userId;
            movieToUpdate.UpdatedDate = DateTime.Now;

            return _context.SaveChanges() > 0;

        }

        public bool DeleteMovieById(int id)
        {
            var movieToDelete = _context.Movies.Single(m => m.Id == id);
            _context.Movies.Remove(movieToDelete);
            return _context.SaveChanges() > 0;
        }

    }
}

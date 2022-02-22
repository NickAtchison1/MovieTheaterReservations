using MovieTheaterReservations.Data.Data;
using MovieTheaterReservations.Data.Models;
using MovieTheaterReservations.DisplayModels.MovieShowing;

namespace MovieTheaterReservations.Services.Services.MovieShowingService
{
    public class MovieShowingService : IMovieShowingService
    {
        private readonly ApplicationDbContext _context;

        public MovieShowingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateMovieShowing(MovieShowingCreate movieShowingCreate, string userId)
        {
            var movieShowingEntity = new MovieShowing()
            {
                MovieId = movieShowingCreate.MovieId,
                AuditoriumId = movieShowingCreate.AuditoriumId,
                MovieShowingDate = movieShowingCreate.MovieShowingDate,
                MovieShowingTime = movieShowingCreate.MovieShowingTime,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now

            };
            _context.MoviesShowings.Add(movieShowingEntity);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<MovieShowingListItem> GetAllMovieShowing()
        {
            var query = _context.MoviesShowings
                .Select(m => new MovieShowingListItem()
                {
                    MovieShowingId = m.Id,
                    MovieTitle = m.Movie.Title,
                    ImageUrl = m.Movie.ImageUrl,
                    MovieShowingDate = m.Movie.CreatedDate,
                    MovieShowingTime = m.MovieShowingTime
                }).ToList();
            return query;

        }

        public MovieShowingDetail GetMovieShowing(int id)
        {
            var movieshowingEntity = _context.MoviesShowings.Single(m => m.Id == id);
            var movieshowingDetail = new MovieShowingDetail()
            {
                MovieShowingId = movieshowingEntity.Id,
                MovieTitle = movieshowingEntity.Movie.Title,
                ImageUrl = movieshowingEntity.Movie.ImageUrl,
                Auditorium = movieshowingEntity.Auditorium.Name,
                MovieShowingDate = movieshowingEntity.MovieShowingDate,
                MovieShowingTime = movieshowingEntity.MovieShowingTime
            };
            return movieshowingDetail;
        }


        public bool UpdateMovieShowing(MovieShowingEdit movieShowingEdit, string userId)
        {
            var movieShowingToUpdate = _context.MoviesShowings.Single(m => m.Id == movieShowingEdit.MovieShowingId);
            movieShowingToUpdate.MovieId = movieShowingEdit.MovieId;
            movieShowingToUpdate.AuditoriumId = movieShowingEdit.AuditoriumId;
            movieShowingToUpdate.MovieShowingDate = movieShowingEdit.MovieShowingDate;
            movieShowingToUpdate.MovieShowingTime = movieShowingEdit.MovieShowingTime;
            movieShowingToUpdate.CreatedBy = movieShowingToUpdate.CreatedBy;
            movieShowingToUpdate.CreatedDate = movieShowingToUpdate.CreatedDate;
            movieShowingToUpdate.UpdatedBy = userId;
            movieShowingToUpdate.UpdatedDate = DateTime.Now;

            return _context.SaveChanges() > 0;
        }

        public bool DeleteMovieShowing(int id)
        {
            var moveShowingToDelete = _context.MoviesShowings.Single(m => m.Id == id);
            _context.MoviesShowings.Remove(moveShowingToDelete);
            return _context.SaveChanges() > 0;
        }
    }
}

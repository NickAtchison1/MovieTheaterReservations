using MovieTheaterReservations.Models.DisplayModels.MovieShowing;

namespace MovieTheaterReservations.Services.Services.MovieShowingService
{
    public interface IMovieShowingService
    {
        bool CreateMovieShowing(MovieShowingCreate movieShowingCreate, string userId);
        bool DeleteMovieShowing(int id);
        IEnumerable<MovieShowingListItem> GetAllMovieShowing();
        MovieShowingDetail GetMovieShowing(int id);
        MovieShowingSeatSelection GetMovieShowingSeats(int id);
        bool UpdateMovieShowing(MovieShowingEdit movieShowingEdit, string userId);
    }
}
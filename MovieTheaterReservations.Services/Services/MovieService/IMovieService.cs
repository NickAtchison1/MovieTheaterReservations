using MovieTheaterReservations.DisplayModels.Movie;
using MovieTheaterReservations.Models.DisplayModels.Movie;

namespace MovieTheaterReservations.Services.Services.MovieService
{
    public interface IMovieService
    {
        bool CreateMovie(MovieCreate movieCreate, string userId);
        bool DeleteMovieById(int id);
        IEnumerable<MovieListItem> GetAllMovies();
        MovieDetail GetMovieTodayById(int id);
        bool UpdateMovie(MovieEdit movieEdit, string userId);
    }
}
using MovieTheaterReservations.DisplayModels.Movie;

namespace MovieTheaterReservations.Services.Services.MovieService
{
    public interface IMovieService
    {
        bool CreateMovie(MovieCreate movieCreate, string userId);
        bool DeleteMovieById(int id);
        IEnumerable<MovieListItem> GetAllMovies();
        MovieDetail GetMovieById(int id);
        bool UpdateMovie(MovieEdit movieEdit, string userId);
    }
}
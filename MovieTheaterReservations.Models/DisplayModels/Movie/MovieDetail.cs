using MovieTheaterReservations.Models.DisplayModels.Enums;
using MovieTheaterReservations.Models.DisplayModels.MovieShowing;

namespace MovieTheaterReservations.DisplayModels.Movie
{
    public class MovieDetail
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public int Duration { get; set; }
        public IEnumerable<MovieShowingTimes>? ShowTimes { get; set; }


    }
}

using MovieTheaterReservations.Shared.DisplayModels.Enums;

namespace MovieTheaterReservations.Shared.DisplayModels.Movie
{
    public class MovieListItem
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Rating Rating { get; set; }

    }
}

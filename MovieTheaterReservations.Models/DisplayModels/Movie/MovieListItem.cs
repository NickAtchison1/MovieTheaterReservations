using MovieTheaterReservations.DisplayModels.Enums;
using MovieTheaterReservations.Models.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Movie
{
    public class MovieListItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Rating Rating { get; set; }

    }
}

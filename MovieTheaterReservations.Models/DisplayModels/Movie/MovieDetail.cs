using MovieTheaterReservations.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Movie
{
    public class MovieDetail
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public int Duration { get; set; }


    }
}

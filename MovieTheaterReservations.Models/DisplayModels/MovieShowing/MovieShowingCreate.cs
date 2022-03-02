using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheaterReservations.Models.DisplayModels.MovieShowing
{
    public class MovieShowingCreate
    {
        public int MovieId { get; set; }
        public int AuditoriumId { get; set; }
        [Column(TypeName = "date")]
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
    }
}

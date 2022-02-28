using MovieTheaterReservations.DisplayModels.Seat;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheaterReservations.Models.DisplayModels.MovieShowing
{
    public class MovieShowingSeatSelection
    {
        public int MovieShowingId { get; set; }
        //public int AvaialbeSeats { get; set; }
        //public int ReserveSeats { get; set; }
        //public int SeatsSelected { get; set; }
          public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string ImageUrl {  get; set; } = string.Empty;
        public int AuditoriumId { get; set; }

        public int SeatId { get; set; }
        public string Auditorium { get; set; } = String.Empty;
        [Column(TypeName = "date")]
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
        public IEnumerable<SeatListItem>? SeatLists { get; set; }

        //  public IEnumerable<TicketListItem> TicketsList { get; set; }
    }
}

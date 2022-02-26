using MovieTheaterReservations.DisplayModels.Enums;
using MovieTheaterReservations.Models.DisplayModels.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheaterReservations.DisplayModels.Ticket
{
    public class TicketDetail
    {
        public int TicketId { get; set; }
        public int MovieShowingId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public string AuditoriumName { get; set; } = string.Empty;
        [Column(TypeName = "date")]
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
        public int SeatId { get; set; }
        public string SeatName { get; set; } = string.Empty;
      //  public int ReservationId { get; set; }
        public decimal TicketPrice { get; set; }
        public TicketType TicketType { get; set; }
        public ShowingType ShowingType { get; set; }
    }
}

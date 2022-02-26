using MovieTheaterReservations.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Ticket
{
    public class TicketEdit
    {
        public int TicketId { get; set; }
        public int MovieShowingId { get; set; }
        public int AuditoriumId { get; set; }
        public int SeatId { get; set; }
     //   public int ReservationId { get; set; }
        public decimal TicketPrice { get; set; }
        public TicketType TicketType { get; set; }
        public ShowingType ShowingType { get; set; }
    }
}

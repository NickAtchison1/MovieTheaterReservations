using MovieTheaterReservations.DisplayModels.Enums;
using MovieTheaterReservations.DisplayModels.Seat;

namespace MovieTheaterReservations.DisplayModels.Reservation
{
    public class ReservationCreate
    {
        public int MovieShowingId { get; set; }
        public int AuditoriumId { get; set; }
        public ReservationType ReservationType { get; set; }
        public ReservationContactType ReservationContactType { get; set; }
      //  public int NumberOfTickets { get; set; }
        public IEnumerable<SeatListItem>? SeatLists { get; set; }
    }
}

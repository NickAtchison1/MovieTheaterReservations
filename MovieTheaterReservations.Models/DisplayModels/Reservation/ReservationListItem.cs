using MovieTheaterReservations.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Reservation
{
    public class ReservationListItem
    {
        public int ReservationId { get; set; }
        public string Movie { get; set; } = String.Empty;
        public ReservationType ReservationType { get; set; }
        public ReservationContactType ReservationContactType { get; set; }
    }
}

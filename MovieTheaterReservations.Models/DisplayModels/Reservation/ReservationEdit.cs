using MovieTheaterReservations.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Reservation
{
    public class ReservationEdit
    {
        public int ReservationId { get; set; }
        public int MovieShowingId { get; set; }
        public ReservationType ReservationType { get; set; }
        public ReservationContactType ReservationContactType { get; set; }
    }
}

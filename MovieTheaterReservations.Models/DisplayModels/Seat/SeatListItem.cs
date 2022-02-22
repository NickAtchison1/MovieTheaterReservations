using MovieTheaterReservations.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Seat
{
    public class SeatListItem
    {
        public int SeatId { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public SeatType SeatType { get; set; }
        public int AuditoriumId { get; set; }
    }
}

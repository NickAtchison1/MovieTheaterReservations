using MovieTheaterReservations.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Seat
{
    public class SeatListItem
    {
        public int SeatId { get; set; }
        public string SeatName { get; set; } = string.Empty;
        public SeatType SeatType { get; set; }
        public int AuditoriumId { get; set; }
    }
}

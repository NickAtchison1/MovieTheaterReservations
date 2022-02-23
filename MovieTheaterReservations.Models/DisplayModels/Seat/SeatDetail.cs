using MovieTheaterReservations.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Seat
{
    public class SeatDetail
    {
        public int SeatId { get; set; }
        public string Row { get; set; } = string.Empty;
        public int SeatNumber { get; set; }
        public SeatType SeatType { get; set; }
        public int AuditoriumId { get; set; }
        public string AuditoriumName { get; set; } = string.Empty;

    }
}

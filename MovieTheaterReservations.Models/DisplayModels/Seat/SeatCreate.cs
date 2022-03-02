using MovieTheaterReservations.DisplayModels.Enums;
using MovieTheaterReservations.Models.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Seat
{
    public class SeatCreate
    {
        public string Row { get; set; }
        public int SeatNumber { get; set; }
        public SeatType SeatType { get; set; }
        public int AuditoriumId { get; set; }

    }
}

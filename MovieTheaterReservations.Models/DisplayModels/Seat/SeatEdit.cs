using MovieTheaterReservations.DisplayModels.Enums;
using MovieTheaterReservations.Models.DisplayModels.Enums;

namespace MovieTheaterReservations.DisplayModels.Seat
{
    public class SeatEdit
    {
        public int SeatId { get; set; }
        public string Row { get; set; } = string.Empty;
        public int SeatNumber { get; set; }
        public SeatType SeatType { get; set; }
        public int AuditoriumId { get; set; }
        //public string UpdatedBy { get; set; } = string.Empty;

        //[Column(TypeName = "datetime2")]
        //public DateTime UpdatedDate { get; set; }
    }
}

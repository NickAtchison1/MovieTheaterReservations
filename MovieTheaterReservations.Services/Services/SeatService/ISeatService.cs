using MovieTheaterReservations.DisplayModels.Seat;

namespace MovieTheaterReservations.Services.Services.SeatService
{
    public interface ISeatService
    {
        bool CreateSeat(SeatCreate seatCreate, string userId);
        bool DeleteSeat(int id);
        SeatDetail GetSeatById(int id);
        IEnumerable<SeatListItem> GetSeats();
        bool UpdateSeat(SeatEdit seatEdit, string userId);
    }
}
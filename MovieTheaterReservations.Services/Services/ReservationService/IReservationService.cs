using MovieTheaterReservations.DisplayModels.Reservation;

namespace MovieTheaterReservations.Services.Services.ReservationService
{
    public interface IReservationService
    {
        bool CreateReservation(ReservationCreate reservationCreate, string userId);
        bool DeleteReservation(int id);
        IEnumerable<ReservationListItem> GetAllReservations();
        ReservationDetail GetReservation(int id);
        bool UpdateReservation(ReservationEdit reservationEdit, string userId);
    }
}
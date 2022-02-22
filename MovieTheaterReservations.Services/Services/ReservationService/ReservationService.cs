using MovieTheaterReservations.Data.Data;
using MovieTheaterReservations.Data.Models;
using MovieTheaterReservations.DisplayModels.Reservation;

namespace MovieTheaterReservations.Services.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateReservation(ReservationCreate reservationCreate, string userId)
        {
            var reservationEntity = new Reservation()
            {
                MovieShowingId = reservationCreate.MovieShowingId,
                ReservationType = (MovieTheaterReservations.Data.Models.Enums.ReservationType)reservationCreate.ReservationType,
                ReservationContactType = (MovieTheaterReservations.Data.Models.Enums.ReservationContactType)reservationCreate.ReservationContactType,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now
            };
            _context.Reservations.Add(reservationEntity);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<ReservationListItem> GetAllReservations()
        {
            var query = _context.Reservations
                .Select(r => new ReservationListItem()
                {
                    ReservationId = r.Id,
                    Movie = r.MovieShowing.Movie.Title,
                    ReservationType = (MovieTheaterReservations.DisplayModels.Enums.ReservationType)r.ReservationType,
                    ReservationContactType = (MovieTheaterReservations.DisplayModels.Enums.ReservationContactType)r.ReservationContactType
                }).ToList();
            return query;
        }

        public ReservationDetail GetReservation(int id)
        {
            var reservationEntity = _context.Reservations.Single(r => r.Id == id);
            var reservationDetail = new ReservationDetail()
            {
                ReservationId = reservationEntity.Id,
                MovieShowingId = reservationEntity.MovieShowingId,
                MovieTitle = reservationEntity.MovieShowing.Movie.Title,
                ReservationType = (MovieTheaterReservations.DisplayModels.Enums.ReservationType)reservationEntity.ReservationType,
                ReservationContactType = (MovieTheaterReservations.DisplayModels.Enums.ReservationContactType)reservationEntity.ReservationContactType

            };
            return reservationDetail;
        }

        public bool UpdateReservation(ReservationEdit reservationEdit, string userId)
        {
            var reservationToUpdate = _context.Reservations.Single(r => r.Id == reservationEdit.ReservationId);
            reservationToUpdate.MovieShowingId = reservationEdit.MovieShowingId;
            reservationToUpdate.ReservationType = (MovieTheaterReservations.Data.Models.Enums.ReservationType)reservationEdit.ReservationType;
            reservationToUpdate.ReservationContactType = (MovieTheaterReservations.Data.Models.Enums.ReservationContactType)reservationEdit.ReservationContactType;
            reservationToUpdate.CreatedBy = reservationToUpdate.CreatedBy;
            reservationToUpdate.CreatedDate = reservationToUpdate.CreatedDate;
            reservationToUpdate.UpdatedBy = userId;
            reservationToUpdate.UpdatedDate = DateTime.Now;

            return _context.SaveChanges() > 0;
        }

        public bool DeleteReservation(int id)
        {
            var reservationToDelete = _context.Reservations.Single(r => r.Id == id);
            _context.Reservations.Remove(reservationToDelete);
            return _context.SaveChanges() > 0;
        }
    }
}

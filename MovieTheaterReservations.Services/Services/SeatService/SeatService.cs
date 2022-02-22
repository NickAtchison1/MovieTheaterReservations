using MovieTheaterReservations.Data.Data;
using MovieTheaterReservations.Data.Models;
using MovieTheaterReservations.DisplayModels.Seat;

namespace MovieTheaterReservations.Services.Services.SeatService
{
    public class SeatService : ISeatService
    {
        private readonly ApplicationDbContext _context;

        public SeatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateSeat(SeatCreate seatCreate, string userId)
        {
            var seatEntity = new Seat()
            {
                RowNumber = seatCreate.RowNumber,
                SeatNumber = seatCreate.SeatNumber,
                SeatType = (MovieTheaterReservations.Data.Models.Enums.SeatType)seatCreate.SeatType,
                AuditoriumId = seatCreate.AuditoriumId,

            };
            _context.Seats.Add(seatEntity);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<SeatListItem> GetSeats()
        {
            var query = _context.Seats
                .Select(s => new SeatListItem()
                {
                    SeatId = s.Id,
                    RowNumber = s.RowNumber,
                    SeatNumber = s.SeatNumber,
                    SeatType = (MovieTheaterReservations.DisplayModels.Enums.SeatType)s.SeatType,
                    AuditoriumId = s.AuditoriumId

                }).ToList();
            return query;
        }

        public SeatDetail GetSeatById(int id)
        {
            var seatEntity = _context.Seats.Single(s => s.Id == id);
            var seatDetail = new SeatDetail()
            {
                SeatId = seatEntity.Id,
                RowNumber = seatEntity.RowNumber,
                SeatNumber = seatEntity.SeatNumber,
                SeatType = (MovieTheaterReservations.DisplayModels.Enums.SeatType)seatEntity.SeatType,
                AuditoriumId = seatEntity.AuditoriumId,
                AuditoriumName = seatEntity.Auditorium.Name
            };
            return seatDetail;
        }

        public bool UpdateSeat(SeatEdit seatEdit, string userId)
        {
            var seatToUpdate = _context.Seats.Single(s => s.Id == seatEdit.SeatId);
            seatToUpdate.RowNumber = seatEdit.RowNumber;
            seatToUpdate.SeatNumber = seatEdit.SeatNumber;
            seatToUpdate.SeatType = (MovieTheaterReservations.Data.Models.Enums.SeatType)seatEdit.SeatType;
            seatToUpdate.AuditoriumId = seatEdit.AuditoriumId;
            seatToUpdate.CreatedBy = seatToUpdate.CreatedBy;
            seatToUpdate.CreatedDate = seatToUpdate.CreatedDate;
            seatToUpdate.UpdatedBy = userId;
            seatToUpdate.UpdatedDate = DateTime.Now;

            return _context.SaveChanges() > 0;
        }

        public bool DeleteSeat(int id)
        {
            var seatToDeleate = _context.Seats.Single(s => s.Id == id);
            _context.Seats.Remove(seatToDeleate);
            return _context.SaveChanges() > 0;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MovieTheaterReservations.Data.Data;
using MovieTheaterReservations.Data.Models;
using MovieTheaterReservations.DisplayModels.Ticket;
using MovieTheaterReservations.Models.DisplayModels.MovieShowing;

namespace MovieTheaterReservations.Services.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateTicket(TicketCreate ticketCreate, string userId)
        {
            //var movieshowingEntity = _context.MoviesShowings.Include(m => m.Movie).Include(a => a.Auditorium).SingleOrDefault(s => s.Id == id);
          //  var seats = _context.Seats.Where(s => s.AuditoriumId == movieshowingEntity.AuditoriumId).ToList();
            var movieShowings = _context.MoviesShowings.Include(m => m.Movie).Include(a => a.Auditorium).ThenInclude(s => s.Seat).ToList();
            var ticketEntity = new Ticket()

            {
               
                 MovieShowingId = ticketCreate.MovieShowingId,
                 //movieShowings.Single(ms => ms.Id == ticketCreate.MovieShowingId).Id,
                 //movieShowings.Single(ms => ms.Id == ticketCreate.MovieShowingId).Id,
                 
                 SeatId = ticketCreate.SeatId,
                 //=movieShowings.Single(ms => ms.Id == ticketCreate.SeatId).Id,
                 //movieShowings.Single(ms => ms.Id == ticketCreate.SeatId).Id,

                TicketPrice = ticketCreate.TicketPrice,
                TicketType = (MovieTheaterReservations.Data.Models.Enums.TicketType)ticketCreate.TicketType,
                ShowingType = (MovieTheaterReservations.Data.Models.Enums.ShowingType)ticketCreate.ShowingType,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now,
                
               


            };
            _context.Tickets.Add(ticketEntity);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<TicketListItem> GetAllTickets()
        {
            var query = _context.Tickets
                .Select(t => new TicketListItem()
                {
                    TicktId = t.Id,
                    MovieShowingId = t.MovieShowingId,
                    SeatId = t.SeatId,
                   
                }).ToList();
            return query;
        }

        public TicketDetail GetTicket(int id)
        {
            var ticketEntity = _context.Tickets.Single(t => t.Id == id);
            var ticketDetail = new TicketDetail()
            {
                TicketId = ticketEntity.Id,
                MovieShowingId = ticketEntity.MovieShowingId,
                MovieTitle = ticketEntity.MovieShowing.Movie.Title,
                Rating = (MovieTheaterReservations.Models.DisplayModels.Enums.Rating)ticketEntity.MovieShowing.Movie.Rating,
                AuditoriumName = ticketEntity.MovieShowing.Auditorium.Name,
                MovieShowingDate = ticketEntity.MovieShowing.MovieShowingDate,
                MovieShowingTime = ticketEntity.MovieShowing.MovieShowingTime,
                SeatId = ticketEntity.SeatId,
                SeatName = ticketEntity.Seat.SeatName,
                
                TicketPrice = ticketEntity.TicketPrice,
                TicketType = (MovieTheaterReservations.DisplayModels.Enums.TicketType)ticketEntity.TicketType,
                ShowingType = (MovieTheaterReservations.DisplayModels.Enums.ShowingType)ticketEntity.ShowingType

            };
            return ticketDetail;
        }

        public bool UpdateTicket(TicketEdit ticketEdit, string userId)
        {
            var ticketToUpdate = _context.Tickets.Single(t => t.Id == ticketEdit.TicketId);

            ticketToUpdate.MovieShowingId = ticketEdit.MovieShowingId;
            ticketToUpdate.SeatId = ticketEdit.SeatId;
           
            ticketToUpdate.TicketPrice = ticketEdit.TicketPrice;
            ticketToUpdate.TicketType = (MovieTheaterReservations.Data.Models.Enums.TicketType)ticketEdit.TicketType;
            ticketToUpdate.ShowingType = (MovieTheaterReservations.Data.Models.Enums.ShowingType)ticketEdit.ShowingType;
            ticketToUpdate.CreatedBy = ticketToUpdate.CreatedBy;
            ticketToUpdate.CreatedDate = ticketToUpdate.CreatedDate;
            ticketToUpdate.UpdatedBy = userId;
            ticketToUpdate.UpdatedDate = DateTime.Now;

            return _context.SaveChanges() > 0;
        }

        public bool DeleteTicket(int id)
        {
            var ticketToDelete = _context.Tickets.Single(t => t.Id == id);
            _context.Tickets.Remove(ticketToDelete);
            return _context.SaveChanges() > 0;
        }

    }
}

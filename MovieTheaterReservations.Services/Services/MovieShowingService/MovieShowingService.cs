using Microsoft.EntityFrameworkCore;
using MovieTheaterReservations.Data.Data;
using MovieTheaterReservations.Data.Models;
using MovieTheaterReservations.DisplayModels.Seat;
using MovieTheaterReservations.DisplayModels.Ticket;
using MovieTheaterReservations.Models.DisplayModels.MovieShowing;

namespace MovieTheaterReservations.Services.Services.MovieShowingService
{
    public class MovieShowingService : IMovieShowingService
    {
        private readonly ApplicationDbContext _context;

        public MovieShowingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateMovieShowing(MovieShowingCreate movieShowingCreate, string userId)
        {
            var movieShowingEntity = new MovieShowing()
            {
                MovieId = movieShowingCreate.MovieId,
                AuditoriumId = movieShowingCreate.AuditoriumId,
                MovieShowingDate = movieShowingCreate.MovieShowingDate,
                MovieShowingTime = movieShowingCreate.MovieShowingTime,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                UpdatedBy = userId,
                UpdatedDate = DateTime.Now

            };
            _context.MoviesShowings.Add(movieShowingEntity);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<MovieShowingListItem> GetAllMovieShowing()
        {
            var query = _context.MoviesShowings
                .Select(m => new MovieShowingListItem()
                {
                    MovieShowingId = m.Id,
                    MovieId = m.Movie.Id,
                    MovieTitle = m.Movie.Title,
                    AuditoriumId = m.AuditoriumId,
                    MovieShowingDate = m.MovieShowingDate,
                    MovieShowingTime = m.MovieShowingTime
                }).ToList();
            return query;

        }

        public MovieShowingDetail GetMovieShowing(int id)
        {
            var movieshowingEntity = _context.MoviesShowings.Include(m => m.Movie).Include(a => a.Auditorium).SingleOrDefault(s => s.Id == id);
            return new MovieShowingDetail()
            {
                MovieShowingId = movieshowingEntity.Id,
                MovieId= movieshowingEntity.Movie.Id,
                MovieTitle = movieshowingEntity.Movie.Title,
                ImageUrl = movieshowingEntity.Movie.ImageUrl,
                Auditorium = movieshowingEntity.Auditorium.Name,
                MovieShowingDate = movieshowingEntity.MovieShowingDate,
                MovieShowingTime = movieshowingEntity.MovieShowingTime
            };
          //  return movieshowingDetail;
        }

        public MovieShowingSeatSelection GetMovieShowingSeats(int id)
        {
            //var movieshowingEntity = (from m in _context.MoviesShowings
            //                          let query = (from s in _context.Seats
            //                                       select new MovieShowingSeatSelection())
            //                                       where m.Id == id
            //                          select new {MovieShowingDetail = m, seats = query.ToList()}).Single();
            var movieshowingEntity = _context.MoviesShowings.Include(m => m.Movie).Include(a => a.Auditorium).SingleOrDefault(s => s.Id == id);
            var seats = _context.Seats.Where(s => s.AuditoriumId == movieshowingEntity.AuditoriumId).ToList();
            // var seat = _context.Seats.Where(s => s.AuditoriumId == movieshowingEntity.AuditoriumId).Where
            // var seats = seatsList.GroupBy(item => item.SeatName.Substring(0, 1))
            //    .SelectMany(grouping => grouping.OrderBy(item => item.Id).ToList());



            //   var tickets = _context.Tickets.Where(t => t.MovieShowingId == movieshowingEntity.Id).ToList();
            var movieShowingSeatDetail = new MovieShowingSeatSelection()
            {
                MovieShowingId = movieshowingEntity.Id,
                MovieId = movieshowingEntity.Movie.Id,
                MovieTitle = movieshowingEntity.Movie.Title,
                ImageUrl = movieshowingEntity.Movie.ImageUrl,
                AuditoriumId = movieshowingEntity.Auditorium.Id,
                Auditorium = movieshowingEntity.Auditorium.Name,
               
               
                
                MovieShowingDate = movieshowingEntity.MovieShowingDate.Date,
                MovieShowingTime = movieshowingEntity.MovieShowingTime,
                SeatLists = (List<SeatListItem>)seats.Select(s => new SeatListItem()
                {
                    SeatId = s.Id,
                    SeatName = s.SeatName,
                    SeatType = (MovieTheaterReservations.Models.DisplayModels.Enums.SeatType)s.SeatType,
                    AuditoriumId = s.AuditoriumId

                }).OrderBy(x => x.SeatType).ToList(),
                

                //TicketsList = (List<TicketListItem>)tickets.Select(t => new TicketListItem()
                //{
                //    TicktId = t.Id,
                //    MovieShowingId = t.MovieShowingId,
                //    SeatId = t.SeatId,
                //    ReservationId = t.ReservationId
                //}).ToList(),

            };
            return movieShowingSeatDetail;

        }


        public bool UpdateMovieShowing(MovieShowingEdit movieShowingEdit, string userId)
        {
            var movieShowingToUpdate = _context.MoviesShowings.Single(m => m.Id == movieShowingEdit.MovieShowingId);
            movieShowingToUpdate.MovieId = movieShowingEdit.MovieId;
            movieShowingToUpdate.Movie.Title = movieShowingEdit.MovieName;
            movieShowingToUpdate.AuditoriumId = movieShowingEdit.AuditoriumId;
            movieShowingToUpdate.Auditorium.Name = movieShowingEdit.AuditoriumName;
            movieShowingToUpdate.MovieShowingDate = movieShowingEdit.MovieShowingDate;
            movieShowingToUpdate.MovieShowingTime = movieShowingEdit.MovieShowingTime;
            movieShowingToUpdate.CreatedBy = movieShowingToUpdate.CreatedBy;
            movieShowingToUpdate.CreatedDate = movieShowingToUpdate.CreatedDate;
            movieShowingToUpdate.UpdatedBy = userId;
            movieShowingToUpdate.UpdatedDate = DateTime.Now;

            return _context.SaveChanges() > 0;
        }

        public bool DeleteMovieShowing(int id)
        {
            var moveShowingToDelete = _context.MoviesShowings.Single(m => m.Id == id);
            _context.MoviesShowings.Remove(moveShowingToDelete);
            return _context.SaveChanges() > 0;
        }
    }
}

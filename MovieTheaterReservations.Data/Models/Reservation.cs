using MovieTheaterReservations.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Data.Models
{
    public class Reservation :BaseRequirement
    {
        private int _numberOfTickets;
    
        public int Id { get; set; }
        public int MovieShowingId { get; set; }
        public MovieShowing? MovieShowing { get; set; }
        public ReservationType ReservationType { get; set; }
        public ReservationContactType ReservationContactType { get; set; }
        public string ContactInformation { get; set; } = string.Empty;
        public int NumberOfTickets
        {
            get
            {
                _numberOfTickets = Tickets.Count;
                return _numberOfTickets;
            }
            set
            {
                _numberOfTickets = value;
            }
        }

        public ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
        

    }
}

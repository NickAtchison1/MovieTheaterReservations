﻿using MovieTheaterReservations.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Data.Models
{
    public class Reservation :BaseRequirement
    { 
    
        public int Id { get; set; }
        public int MovieShowingId { get; set; }
        public MovieShowing? MovieShowing { get; set; }
        public ReservationType ReservationType { get; set; }
        public ReservationContactType ReservationContactType { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
        

    }
}

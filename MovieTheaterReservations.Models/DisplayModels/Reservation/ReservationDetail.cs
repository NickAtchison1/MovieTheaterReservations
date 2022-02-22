﻿using MovieTheaterReservations.Shared.DisplayModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Shared.DisplayModels.Reservation
{
    public class ReservationDetail
    {
        public int ReservationId { get; set; }
        public int MovieShowingId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public ReservationType ReservationType { get; set; }
        public ReservationContactType ReservationContactType { get; set; }
      //  public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}

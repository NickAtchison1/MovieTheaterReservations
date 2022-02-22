﻿using MovieTheaterReservations.Shared.DisplayModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Shared.DisplayModels.Reservation
{
    public  class ReservationCreate
    {
        public int MovieShowingId { get; set; }
        public ReservationType ReservationType { get; set; }
        public ReservationContactType ReservationContactType { get; set; }
    }
}

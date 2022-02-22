﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.DisplayModels.MovieShowing
{
    public class MovieShowingEdit
    {
        public int MovieShowingId { get; set; }
        public int MovieId { get; set; }
        public int AuditoriumId { get; set; }
        [Column(TypeName = "date")]
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
    }
}

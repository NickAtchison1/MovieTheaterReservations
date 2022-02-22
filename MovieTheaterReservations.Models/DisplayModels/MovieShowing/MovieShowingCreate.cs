﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Shared.DisplayModels.MovieShowing
{
    public class MovieShowingCreate
    {
        public int MovieId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int AuditoriumId { get; set; }
        [Column(TypeName = "date")]
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
    }
}

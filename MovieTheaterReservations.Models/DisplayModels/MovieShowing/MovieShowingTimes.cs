using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Models.DisplayModels.MovieShowing
{
    public class MovieShowingTimes
    {
        public int MovieShowingId { get; set; }
        public int MovieId { get; set; }   
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
    }
}

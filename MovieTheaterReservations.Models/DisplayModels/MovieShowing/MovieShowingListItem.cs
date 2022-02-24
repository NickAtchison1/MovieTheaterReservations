using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Models.DisplayModels.MovieShowing
{
    public class MovieShowingListItem
    {
        public int MovieShowingId { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int AuditoriumId {  get; set; }
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
    }
}

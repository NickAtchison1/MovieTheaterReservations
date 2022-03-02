using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Models.DisplayModels.MovieShowing
{
    public class MovieShowingEdit
    {
        public int MovieShowingId { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public int AuditoriumId { get; set; }
        public string AuditoriumName { get; set;} = string.Empty;
        [Column(TypeName = "date")]
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Models.DisplayModels.MovieShowing
{
    public class MovieShowingAuditorium
    {
        public int MovieShowingId { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
       
        public int AuditoriumId { get; set; }
        public string Auditorium { get; set; } = String.Empty;
        [Column(TypeName = "date")]
        public DateTime MovieShowingDate { get; set; }
        public TimeSpan MovieShowingTime { get; set; }
        
    }
}

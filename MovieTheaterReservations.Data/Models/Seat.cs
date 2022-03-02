using MovieTheaterReservations.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterReservations.Data.Models
{
    public class Seat : BaseRequirement
    { private string? _seatName;
        public int Id { get; set; }
        [Required]
        [MaxLength(4)]
        public string Row { get; set; } = String.Empty;
        [Required]
        public int SeatNumber { get; set; }
        public string SeatName
        {
            get
            {
                _seatName = $"{Row}{SeatNumber.ToString()}";
                return _seatName;
            }
            set {  _seatName = value; }
        }
        public SeatType SeatType { get; set; }
        public int AuditoriumId { get; set; }
        public Auditorium? Auditorium { get; set; }
      
    }
}

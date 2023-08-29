using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int AvailablSeats { get; set; }
        public DateTime BookingTime { get; set; }

        public int Status { get; set; }

        // User, Movie, and Seat properties need to be added
       
        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        public virtual Movie Movie { get; set; }

        // Foreign key relationship with Seat entity
        [ForeignKey("Seat")]
        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }

        //public virtual OrderFood OrderFood { get; set; }
        //public virtual Payment Payment { get; set; }
    }
}

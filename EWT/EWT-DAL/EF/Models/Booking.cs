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
        public int AvailablSeats { get;set; }
        public DateTime BookingTime { get; set; }
        public int Status { get; set; }

        //user,movie,seat propertties need to be added 
        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        [ForeignKey("Seat")]
        public int SeatId { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual Seat Seat { get; set; }  
        //food,payment--


    }
}

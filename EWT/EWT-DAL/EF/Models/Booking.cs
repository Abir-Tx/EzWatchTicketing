using System;
using System.Collections.Generic;
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

    }
}

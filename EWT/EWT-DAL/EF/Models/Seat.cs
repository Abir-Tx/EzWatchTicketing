using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class Seat
    {
        public int Id { get; set; } 
        public string SeatName { get; set; }    
        public string SeatType { get; set; }
        [ForeignKey("Hall")] 
        
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class OrderFood
    {   
        public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        [ForeignKey("Food")]
        public int FoodID { get; set; }
        public virtual Food Food { get; set; }
        public virtual Booking Booking { get; set; }    
    }
}

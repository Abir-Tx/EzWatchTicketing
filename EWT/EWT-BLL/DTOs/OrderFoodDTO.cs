using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_BLL.DTOs
{
    public class OrderFoodDTO
    {

        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BookingId { get; set; }
        
        public int FoodID { get; set; }
    }
}

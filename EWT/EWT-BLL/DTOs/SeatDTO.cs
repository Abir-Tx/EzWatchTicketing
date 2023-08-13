using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_BLL.DTOs
{
    public class SeatDTO
    {
        public int Id { get; set; }
        public string SeatName { get; set; }
        public string SeatType { get; set; }
       

        public int HallId { get; set; }
    }
}

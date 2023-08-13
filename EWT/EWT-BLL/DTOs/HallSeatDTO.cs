using EWT_DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_BLL.DTOs
{
    public class HallSeatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<SeatDTO> SeatsDTO { get; set; }
        public HallSeatDTO()
        {
            SeatsDTO = new List<SeatDTO>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_BLL.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public DateTime Created { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }
    }
}

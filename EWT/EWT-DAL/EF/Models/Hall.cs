using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int TotalSeats { get; set; }

        public ICollection<Seat> Seats { get; set; }
        public Hall()
        {
            Seats = new List<Seat>();
        }
        //add movieid
      //  [ForeignKey("Movie")]
        //   public int MovieId { get; set; }
        //  public virtual Movie Movie { get; set; }

    }
}

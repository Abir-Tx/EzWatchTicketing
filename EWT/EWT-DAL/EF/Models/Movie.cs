using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int Duration { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Poster { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
        public Movie() {
            Ticket = new List<Ticket>();
        }
    }
}

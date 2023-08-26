using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public DateTime Created { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public int MovieId { get; set; } //FK
        public virtual Movie Movie { get; set; }
    }
}

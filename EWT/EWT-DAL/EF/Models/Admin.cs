using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class Admin 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }
        public double Salary { get; set; }

        public string City { get; set; }

    }
}

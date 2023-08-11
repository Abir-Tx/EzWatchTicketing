using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] [StringLength(100)] public string Email { get; set; }
        [Required] [StringLength(20)] public string Password { get; set; }
    }
}

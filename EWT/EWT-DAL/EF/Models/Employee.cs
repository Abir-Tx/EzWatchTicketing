using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EWT_DAL.EF.Models
{
    public class Employee
    {
        [Key] public int Id { get; set; }
        [Required] [StringLength(20)] public string Password { get; set; }
        [Required] [StringLength(100)] public string Email { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Name { get; set; }
        public string Address { get; set; }
        [Required] public double Salary { get; set; }

        public int RoleId { get; set; } // Foreign key
        public virtual Role Role { get; set; } // Navigation property
    }
}

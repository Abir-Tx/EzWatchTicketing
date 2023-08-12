using EWT_DAL.EF.Models;
using System.Data.Entity;

namespace EWT_DAL.EF
{
    public class EWTContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

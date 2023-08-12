using EWT_DAL.EF.Models;
using System.Data.Entity;

namespace EWT_DAL.EF
{
    public class EWTContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hall> Halls { get; set; }  
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Seat> Seats { get; set; }
    }
}

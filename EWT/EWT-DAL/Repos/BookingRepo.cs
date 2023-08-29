using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Repos
{
    internal class BookingRepo : Repo, IRepo<Booking, int, bool>
    {
        public bool Create(Booking obj)
        {
            db.Bookings.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking == null)
                return false;
            db.Bookings.Remove(booking);
            return db.SaveChanges() > 0;
        }

        public List<Booking> Get()
        {
            return db.Bookings.ToList();    

        }

        public Booking Get(int id)
        {
            return db.Bookings.Find(id);
        }

        public bool Update(Booking obj)
        {
            var bookingexp = db.Bookings.Find(obj.Id);
            if (bookingexp == null)
            {
                return false;
            }
            bookingexp.Id = obj.Id;
            bookingexp.AvailablSeats = obj.AvailablSeats;
            bookingexp.BookingTime = obj.BookingTime;
            bookingexp.Status = obj.Status; 
            db.Bookings.AddOrUpdate(bookingexp);
            return db.SaveChanges() > 0;
        }
    }
}

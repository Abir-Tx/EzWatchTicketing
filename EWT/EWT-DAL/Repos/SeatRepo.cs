using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using EWT_DAL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Repos
{
    internal class SeatRepo : Repo, IRepo<Seat, int, bool>
    {
        public bool Create(Seat obj)
        {
            db.Seats.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var seat = db.Seats.Find(id);
            if (seat == null)
                return false;

            db.Seats.Remove(seat);
            return db.SaveChanges() > 0;
        }

        public List<Seat> Get()
        {
            return db.Seats.ToList();
        }

        public Seat Get(int id)
        {
            return db.Seats.Find(id);
        }

        public bool Update(Seat obj)
        {
            var seatToUpdate = db.Seats.Find(obj.Id);
            if (seatToUpdate == null)
                return false;

            seatToUpdate.SeatName = obj.SeatName;
            seatToUpdate.SeatType = obj.SeatType;
            seatToUpdate.HallId = obj.HallId;

            db.Seats.AddOrUpdate(seatToUpdate);
            return db.SaveChanges() > 0;
        }
    }
}

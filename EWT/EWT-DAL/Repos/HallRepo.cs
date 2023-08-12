using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Repos
{
    internal class HallRepo : Repo, IRepo<Hall, int, bool>
    {
        public bool Create(Hall obj)
        {
            db.Halls.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exp = Get(id);
            db.Halls.Remove(exp);
            return db.SaveChanges() > 0;
        }

        public List<Hall> Get()
        {
           return db.Halls.ToList();
        }

        public Hall Get(int id)
        {
            return db.Halls.Find(id);

        }

        public bool Update(Hall obj)
        {
            var exp = Get(obj.Id);
            db.Entry(exp).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Repos
{
    internal class OrderFoodRepo : Repo, IRepo<OrderFood, int, bool>
    {
    
public bool Create(OrderFood obj)
        {
            db.OrderFoods.Add(obj);
           return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var orderFood= db.OrderFoods.Find(id);
            if (orderFood != null)
            {
                db.OrderFoods.Remove(orderFood);
                return db.SaveChanges() > 0;

             }
            else { return false; }  
        }

        public List<OrderFood> Get()
        {
            return db.OrderFoods.ToList();

        }

        public OrderFood Get(int id)
        {
            return db.OrderFoods.Find(id);
        }

        public bool Update(OrderFood obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            return db.SaveChanges() > 0;    
        }
    }
}

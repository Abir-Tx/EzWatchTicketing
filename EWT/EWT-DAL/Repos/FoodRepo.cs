using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Repos
{
    internal class FoodRepo : Repo, IRepo<Food, int, bool>
    {
        public bool Create(Food obj)
        {
            db.Foods.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
           var food= db.Foods.Find(id); 
           if(food== null) 
                return false;
           db.Foods.Remove(food);
            return db.SaveChanges() > 0;
        }

        public List<Food> Get()
        {
            return db.Foods.ToList();
        }

        public Food Get(int id)
        {
            return db.Foods.Find(id);
        }

        public bool Update(Food obj)
        {
            var foodexp=db.Foods.Find(obj.Id);
            if (foodexp== null)
            {
                return false;
            }
            foodexp.Id = obj.Id;  
            foodexp.Name = obj.Name;
            foodexp.Price = obj.Price;  
            foodexp.Description = obj.Description;
            db.Foods.AddOrUpdate(foodexp);
            return db.SaveChanges() > 0;
        }
    }
}

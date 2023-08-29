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
    internal class PaymentRepo : Repo, IRepo<Payment, int, bool>
    {
        public bool Create(Payment obj)
        {
            db.Payments.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var payment = db.Payments.Find(id);
            if (payment == null)
                return false;

            db.Payments.Remove(payment);
            return db.SaveChanges() > 0;
        }

        public List<Payment> Get()
        {
            return db.Payments.ToList();
        }

        public Payment Get(int id)
        {
            return db.Payments.Find(id);
        }

        public bool Update(Payment obj)
        {
            var paymentToUpdate = db.Payments.Find(obj.Id);
            if (paymentToUpdate == null)
                return false;


            db.Payments.AddOrUpdate(paymentToUpdate);
            return db.SaveChanges() > 0;
        }
    }
}

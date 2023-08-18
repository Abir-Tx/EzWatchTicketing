using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public List<Payment> Get()
        {
            return db.Payments.ToList();    
        }

        public Payment Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Payment obj)
        {
            throw new NotImplementedException();
        }
    }
}

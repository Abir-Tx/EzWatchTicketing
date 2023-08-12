using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EWT_DAL.Repos
{
    internal class EmployeeRepo : Repo, IRepo<Employee, int, bool>
    {
        public bool Create(Employee obj)
        {
            db.Employees.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Get()
        {
          return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);

        }

        public bool Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}

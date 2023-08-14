using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EWT_DAL.Repos
{
    internal class EmployeeRepo : Repo, IRepo<Employee, int, bool>, IAuth<Employee>
    {
        public Employee Authenticate(string username, string password)
        {
            var data = from emp in db.Employees
                       where emp.Username.Equals(username)
                       && emp.Password.Equals(password)
                       select emp;
            return data.SingleOrDefault();
        }

        public bool Create(Employee obj)
        {
            db.Employees.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var employeeToDelete = db.Employees.FirstOrDefault(emp => emp.Id == id);
            if (employeeToDelete != null)
            {
                db.Employees.Remove(employeeToDelete);
                return db.SaveChanges() > 0;
            }
            return false;
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
            var employeeToUpdate = db.Employees.Find(obj.Id);
            if (employeeToUpdate == null)
            {
                return false;
            }

            employeeToUpdate.Id = obj.Id;
            employeeToUpdate.Address = obj.Address;
            employeeToUpdate.Username = obj.Username;
            employeeToUpdate.Password = obj.Password;
            employeeToUpdate.Salary = obj.Salary;
            employeeToUpdate.Email = obj.Email;

            db.Employees.AddOrUpdate(employeeToUpdate);
            return db.SaveChanges() > 0;
        }
    
    }
}

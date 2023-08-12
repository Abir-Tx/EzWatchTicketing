using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using EWT_DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL
{
    public class DataAccesser
    {
        public static IRepo<Employee, string, bool> EmployeeDataAccess()
        {
            return new EmployeeRepo();
        }
    }
}

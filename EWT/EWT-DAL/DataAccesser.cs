
﻿using EWT_DAL.EF.Models;

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


        public static IRepo<Hall, int, bool> HallDataAceess()
        {
            return new HallRepo();
        }


        public static object UserDataAccess()
        {
            throw new NotImplementedException();
        }

        public static IRepo<Payment, int, bool>PaymentDataAccess()
        {
            return new PaymentRepo();
        }

        public static IRepo<Employee, int, bool> EmployeeDataAccess() { return new EmployeeRepo(); }
        // Data Accessor for Movies
        public static IRepo<Movie, int, bool> MovieDataAccess() {  return new MovieRepo(); }
        public static IRepo<Admin, int, bool> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<Ticket, int, bool> TicketDataAccess()
        {
            return new TicketRepo();

        }
    }
}

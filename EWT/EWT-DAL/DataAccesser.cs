
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


        public static IRepo<User, int, bool> UserDataAccess()
        {
            return new UserRepo(); 
        }

        public static IRepo<Payment, int, bool>PaymentDataAccess()
        {
            return new PaymentRepo();
        }
        public static IRepo<Food, int, bool> FoodDataAccess()
        {
            return new FoodRepo();
        }
        public static IRepo<OrderFood, int, bool> OrderFoodDataAccess()
        {
            return new OrderFoodRepo();
        }
        public static IRepo<Booking, int, bool> BookingDataAccess()
        {
            return new BookingRepo();
        }
        public static IRepo<Seat, int, bool> SeatDataAccess()
        {
            return new SeatRepo();
        }



        public static IRepo<Employee, int, bool> EmployeeDataAccess() { return new EmployeeRepo(); }
        // Data Accesser for Movies
        public static IRepo<Movie, int, bool> MovieDataAccess() {  return new MovieRepo(); }
        public static IRepo<Admin, int, bool> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<Ticket, int, bool> TicketDataAccess()
        {
            return new TicketRepo();

        }

        // Token Repo Accesser
        public static IRepo<Token, int, Token> TokenDataAccess() {
            return new TokenRepo();
        }

        public static IAuth<Employee> AuthDataAccess()
        {
            return new EmployeeRepo();
        }
    }
}

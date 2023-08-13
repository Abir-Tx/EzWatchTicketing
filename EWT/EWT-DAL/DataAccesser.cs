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
        public static IRepo<Payment, int, bool>PaymentDataAccess()
        {
            return new PaymentRepo();
        }

    }
}


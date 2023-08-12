﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_BLL.DTOs
{
    public class AdminDTO
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public string Email { get; set; }
         public string Password { get; set; }

        public string Address { get; set; }
        public double Salary { get; set; }

        public string City { get; set; }
    }
}

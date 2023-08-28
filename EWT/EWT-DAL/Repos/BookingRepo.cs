using EWT_DAL.EF.Models;
using EWT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Repos
{
    internal class BookingRepo: Repo, IRepo<Booking, int, bool>
    {
    }
}

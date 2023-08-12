using EWT_DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Repos
{
    internal class Repo
    {
        protected EWTContext db;
        internal Repo()
        {
            db = new EWTContext();
        }
    }
}

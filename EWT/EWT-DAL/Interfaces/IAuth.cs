using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Interfaces
{
    public interface IAuth<CLASS>
    {
        CLASS Authenticate(string username, string password);
    }
}

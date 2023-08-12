﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.Interfaces
{
    public interface IRepo<CLASS, ID, RET>
    {
        List<CLASS> Get();
        CLASS Get(ID id);
        RET Create(CLASS obj);
        bool Delete(ID id);
        RET Update(CLASS obj);
    }
}

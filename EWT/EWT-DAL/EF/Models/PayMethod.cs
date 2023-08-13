using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class PayMethod
    {
        public int Id { get; set; }    
        public string Name { get; set; }
      //  public string Type { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public PayMethod() 
        { 
            Payments = new List<Payment>(); 
        }
        
    }
}

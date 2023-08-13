using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class Payment
    {

        public int Id { get; set; }
       // public string MethodName { get; set; }
        public int Cardnum { get; set; }    
        public DateTime Expirydate { get; set; }
        public int Cvc { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        [ForeignKey("PayMethod")]
        public int payId { get; set; }
        public virtual PayMethod PayMethod{ get; set; }    
    }
}

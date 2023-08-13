using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_BLL.DTOs
{
   public class PaymentDTO
    {
        public int Id { get; set; }
        // public string MethodName { get; set; }
        public int Cardnum { get; set; }
        public DateTime Expirydate { get; set; }
        public int Cvc { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        public int payId { get; set; }
    }
}

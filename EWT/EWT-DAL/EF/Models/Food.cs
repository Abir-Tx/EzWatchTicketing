using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWT_DAL.EF.Models
{
    public class Food
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } 
        public  ICollection<OrderFood>OrderFoods { get; set; }
        public Food()
        {
            OrderFoods = new List<OrderFood>(); 
        }   
    }
}

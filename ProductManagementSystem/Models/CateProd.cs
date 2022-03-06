using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystem.Models
{
    
        public class CateProd
        {
            public int Sno { get; set; }
            public string CategoryName { get; set; }
            public string Title { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
        }
    
}

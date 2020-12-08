using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessObjects
{
    public class ProductNeeds
    {
        public int Quantity { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
    }
}

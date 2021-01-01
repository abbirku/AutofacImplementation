using System;
using System.Collections.Generic;
using System.Text;

namespace Core.BusinessObjects
{
    public class ProductNeeds
    {
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }

        //Here MinAmount must be greater then 10 and MaxAmount must be less then 100
        public bool IsValid()
        {
            return MinAmount > 10 & MaxAmount < 100; //Which is in between 11 to 99
        }
    }
}

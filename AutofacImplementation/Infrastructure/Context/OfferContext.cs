using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    public class OfferContext
    {
        public int MinVal { get; }
        public int MaxVal { get; }

        public OfferContext(int min, int max)
        {
            MinVal = min;
            MaxVal = max;
        }
    }
}

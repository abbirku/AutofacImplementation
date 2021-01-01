using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ViewModels
{
    public class ProductViewModel
    {
        public List<Products> Products { get; set; }
        public Products Product { get; set; }
    }
}

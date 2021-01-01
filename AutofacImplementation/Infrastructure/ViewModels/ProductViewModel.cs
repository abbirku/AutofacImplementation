using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class ProductViewModel
    {
        public List<Products> Products { get; set; }
        public Products Product { get; set; }
    }
}

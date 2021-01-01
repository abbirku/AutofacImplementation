using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.BusinessObjects
{
    public class ProductInfo
    {
        public Products Product { get; set; }

        public ValidationModel IsValid()
        {
            if (Product == null)
                return new ValidationModel { IsValid = false, Message = "No product has been provided" };

            if (string.IsNullOrEmpty(Product.Name))
                return new ValidationModel { IsValid = false, Message = "Product name can not be null or empty" };

            if (Product.Price <= 0)
                return new ValidationModel { IsValid = false, Message = "Each product price can not be zero or negative value" };

            return new ValidationModel { IsValid = true, Message = "Course information is valid" };
        }
    }
}

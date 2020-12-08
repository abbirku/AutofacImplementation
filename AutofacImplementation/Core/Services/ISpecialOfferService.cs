using Core.BusinessObjects;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface ISpecialOfferService
    {
        List<Products> GenerateOffers(ProductNeeds needs);
    }
}

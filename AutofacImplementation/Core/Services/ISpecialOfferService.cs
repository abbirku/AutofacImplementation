using Core.BusinessObjects;
using Core.ViewModels;
using System.Collections.Generic;

namespace Core.Services
{
    public interface ISpecialOfferService
    {
        List<OfferedProducts> GenerateOffers(ProductNeeds needs);
    }
}

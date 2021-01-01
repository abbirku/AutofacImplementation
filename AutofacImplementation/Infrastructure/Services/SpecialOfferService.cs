using Core;
using Infrastructure.BusinessObjects;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.UnitOfWorks;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public interface ISpecialOfferService
    {
        List<OfferedProducts> GenerateOffers(ProductNeeds needs);
    }

    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IShopUnitOfWork _unitOfWork;
        private readonly Random _random;

        public SpecialOfferService(IShopUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _random = new Random();
        }

        public List<OfferedProducts> GenerateOffers(ProductNeeds needs)
        {
            if (!needs.IsValid())
                throw new Exception("Amount range must be in between 10 to 100");

            var offeredProducts = new List<OfferedProducts>();
            var products = _unitOfWork.ProductRepository.GetAll();
            foreach(var product in products)
            {
                var offeredPrice = product.Price - RandomOffer(product.Price);
                if(needs.MinAmount <= offeredPrice && offeredPrice <= needs.MaxAmount)
                {
                    offeredProducts.Add(new OfferedProducts
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        OfferedPrice = offeredPrice
                    });
                }
            }

            return offeredProducts;
        }

        private decimal RandomOffer(decimal price)
        {
            return price * (_random.Next(1, 100) / 100);
        }
    }
}

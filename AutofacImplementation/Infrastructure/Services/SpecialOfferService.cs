using Core.BusinessObjects;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.ViewModels;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IRepository<Products> _repository;
        private readonly Random _random;

        public SpecialOfferService(IRepository<Products> repository)
        {
            _repository = repository;
            _random = new Random();
        }

        public List<OfferedProducts> GenerateOffers(ProductNeeds needs)
        {
            if (!needs.IsValid())
                throw new Exception("Amount range must be in between 10 to 100");

            var offeredProducts = new List<OfferedProducts>();
            var products = _repository.GetAll();
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

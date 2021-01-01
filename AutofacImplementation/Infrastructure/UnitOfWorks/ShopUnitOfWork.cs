using Core;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.UnitOfWorks
{
    public interface IShopUnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; set; }
    }

    public class ShopUnitOfWork : UnitOfWork, IShopUnitOfWork
    {
        public IProductRepository ProductRepository { get; set; }

        public ShopUnitOfWork(ListContext listContext, 
            IProductRepository productRepository)
            : base(listContext)
        {
            ProductRepository = productRepository;
        }
    }
}

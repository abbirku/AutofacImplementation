using Infrastructure.BusinessObjects;
using Infrastructure.Entities;
using Infrastructure.Services;
using Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ProductModel : IDisposable
    {
        private readonly IShopUnitOfWork _productUnitOfWork;
        private readonly IProductService _productService;

        public ProductModel(IShopUnitOfWork courseUnitOfWork, IProductService courseService)
        {
            _productUnitOfWork = courseUnitOfWork;
            _productService = courseService;
        }

        public ProductViewModel CreateProductViewModel(int id = 0, bool isValid = false, string message = "")
        {
            var selectedProduct = new Products { Name = string.Empty, Price = 0 };
            if (id != 0)
            {
                selectedProduct = _productUnitOfWork.ProductRepository.Get(id);
            }

            var model = new ProductViewModel
            {
                Products = _productUnitOfWork.ProductRepository.GetAll(),
                Product = selectedProduct,
                Validation = new ValidationModel { IsValid = isValid, Message = message }
            };

            return model;
        }

        public void Dispose()
        {
            _productService.Dispose();
        }
    }

    public class ProductViewModel
    {
        public Products Product { get; set; }
        public List<Products> Products { get; set; }
        public ValidationModel Validation { get; set; }
    }
}

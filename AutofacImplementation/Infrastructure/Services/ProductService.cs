using Core;
using Infrastructure.BusinessObjects;
using Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IProductService : IDisposable
    {
        ValidationModel CreateProduct(ProductInfo productInfo);
        ValidationModel UpdateProductInfo(ProductInfo productInfo);
        ValidationModel RemoveProduct(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IShopUnitOfWork _shopUnitOfWork;

        public ProductService(IShopUnitOfWork shopUnitOfWork)
        {
            _shopUnitOfWork = shopUnitOfWork;
        }

        public ValidationModel CreateProduct(ProductInfo productInfo)
        {
            try
            {
                var validation = productInfo.IsValid();
                if (!validation.IsValid)
                    return new ValidationModel { IsValid = false, Message = validation.Message };

                _shopUnitOfWork.ProductRepository.Add(productInfo.Product);
                _shopUnitOfWork.SaveChanges();

                return new ValidationModel { IsValid = true, Message = $"{productInfo.Product.Name} has been successfully created." };
            }
            catch (Exception ex)
            {
                //Implement serilog for logging the error message
                throw new Exception(ex.Message);
            }
        }

        public ValidationModel UpdateProductInfo(ProductInfo productInfo)
        {
            try
            {
                var validation = productInfo.IsValid();
                if (!validation.IsValid)
                    throw new Exception(validation.Message);

                _shopUnitOfWork.ProductRepository.Edit(productInfo.Product);
                _shopUnitOfWork.SaveChanges();

                return new ValidationModel { IsValid = true, Message = $"{productInfo.Product.Name} has been successfully updated." };
            }
            catch (Exception ex)
            {
                //Implement serilog for logging the error message
                throw new Exception(ex.Message);
            }
        }

        public ValidationModel RemoveProduct(int id)
        {
            try
            {
                if (id == 0)
                    return new ValidationModel { IsValid = false, Message = "Please provide a valid Id" };

                var product = _shopUnitOfWork.ProductRepository.Get(id);
                if (product == null)
                    throw new Exception("Course does not exists.");

                _shopUnitOfWork.ProductRepository.Delete(product);
                _shopUnitOfWork.SaveChanges();

                return new ValidationModel { IsValid = true, Message = $"{product.Name} has been successfully remove." };
            }
            catch (Exception ex)
            {
                //Implement serilog for logging the error message
                return new ValidationModel { IsValid = false, Message = ex.Message };
            }
        }

        public void Dispose()
        {
            _shopUnitOfWork.Dispose();
        }
    }
}

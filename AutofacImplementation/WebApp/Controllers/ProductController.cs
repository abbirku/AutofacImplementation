using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Infrastructure.BusinessObjects;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int id = 0, bool isValid = false, string message = "")
        {
            var productModel = Startup.AutofacContainer.Resolve<ProductModel>();
            var model = productModel.CreateProductViewModel(id, isValid, message);

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Products product)
        {
            try
            {
                var result = _productService.CreateProduct(new ProductInfo
                {
                    Product = product
                });

                if (result.IsValid)
                    return RedirectToAction("Index", "Product", new { isValid = result.IsValid, message = result.Message });
                else
                    return RedirectToAction("Index", "Error", new { message = result.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Edit(Products product)
        {
            try
            {
                var result = _productService.UpdateProductInfo(new ProductInfo
                {
                    Product = product
                });

                if (result.IsValid)
                    return RedirectToAction("Index", "Product", new { isValid = result.IsValid, message = result.Message });
                else
                    return RedirectToAction("Index", "Error", new { message = result.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var result = _productService.RemoveProduct(id);

                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { message = ex.Message });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Products> _productRepository;

        public ProductController(IRepository<Products> productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(int id = 0)
        {
            var product = new Products();
            if (id != 0)
            {
                product = _productRepository.Get(id);
            }

            var model = new ProductViewModel
            {
                Products = _productRepository.GetAll(),
                Product = product
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Products product)
        {
            _productRepository.Add(product);
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public IActionResult Edit(Products product)
        {
            _productRepository.Edit(product);
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index", "Product");
        }
    }
}

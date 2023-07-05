using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore2_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore2_3.Controllers
{
    public class ProductController : Controller 
    {
        private IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() 
        {
            // var products = repository.Products
            // .Where(i=>i.Category=="Category 1")
            // .FirstOrDefault(i=>i.Price>50); //Category'si 1 olan kayıtlar arasından fiyatı 50'den büyük olan ilk kaydı getir. 

            return View(repository.Products);
        } 

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            repository.CreateProduct(product);
            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            return View(repository.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Details(Product product)
        {
            repository.UpdateProduct(product);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(repository.GetProductById(id));
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            repository.DeleteProduct(product.ProductId);
            return RedirectToAction("List");
        }
    }
}
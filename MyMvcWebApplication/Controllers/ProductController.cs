using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMvcWebApplication.Models;

namespace MyMvcWebApplication.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products =
        [
            new Product() { Id = 101, Name = "Laptop", Price = 1200 },
            new Product() { Id = 102, Name = "Mouse", Price = 3200 }
        ];
        // GET: ProductController
        public ActionResult Index()
        {
            return View(Products);
        }
    }
}

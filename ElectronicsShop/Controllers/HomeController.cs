using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicsShop.Models;
using ElectronicsShop.ViewModels;
using System.Data.Entity;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var products = db.Products
                .Include(d => d.Brand)
                .Include(d => d.Gallery.ImageGalleries);


            //var bestsellersList = new List<Product>();
            //var bestsellers = from items in _context.OrderDetails
            //    group items by new { items.ProductId }
            //    into g
            //    select new { g.Key.ProductId, totalQuantity = g.Sum(items => items.Quantity) };

            //var orderedBestsellers = bestsellers.OrderByDescending(d => d.totalQuantity).Take(8).ToList();

            //foreach (var item in orderedBestsellers)
            //{
            //    bestsellersList.Add(products.FirstOrDefault(d => d.ProductId == item.ProductId));
            //}

            var model = new HomeViewModel()
            {
                Recommended = products.Where(d=>d.IsRecommended).Take(10).ToList()
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
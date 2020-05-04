using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using ElectronicsShop.Models;
using ElectronicsShop.Models.DbModels;
using ElectronicsShop.ViewModels;
using Microsoft.AspNet.Identity;

namespace ElectronicsShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            decimal totalPrice = 0;
            var dailyDeal = db.DailyDeals.FirstOrDefault(d => d.Start < DateTime.Now && d.End > DateTime.Now);

            var shoppingCart = db.ShoppingCarts.Include(d=>d.Product).Where(d => d.ApplicationUserId == userId);

            foreach (var item in shoppingCart)
            {
                totalPrice += (dailyDeal?.ProductId == item.ProductId) ? (dailyDeal.NewPrice * item.Quantity): (item.Product.Price *item.Quantity) ;
            }


            var model = new OrderSummaryViewModel()
            {
                Address = db.Addresses.FirstOrDefault(d => d.ApplicationUserId == userId),
                OrderPrice = totalPrice
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(OrderSummaryViewModel model)
        {
            var userId = User.Identity.GetUserId();
            decimal totalPrice = 0;
            var address = model.Address;
            var dailyDeal = db.DailyDeals.FirstOrDefault(d => d.Start < DateTime.Now && d.End > DateTime.Now);

            var shoppingCart = db.ShoppingCarts.Include(d=>d.Product).Where(d => d.ApplicationUserId == userId);


            foreach (var item in shoppingCart)
            {
                totalPrice += (dailyDeal?.ProductId == item.ProductId) ? (dailyDeal.NewPrice * item.Quantity): (item.Product.Price *item.Quantity) ;
            }

            if (!db.Addresses.Any(d=>d.ApplicationUserId == userId))
            {
                address.ApplicationUserId = userId;
            }

            db.Addresses.Add(address);
            db.SaveChanges();

            var order = new Order()
            {
                AddressId = address.Id,
                ApplicationUserId = userId,
                Message = model.Message,
                TotalPrice = totalPrice,
                OrderDate = DateTime.Now
            };

            db.Orders.Add(order);
            db.SaveChanges();

            var orderDetails = new List<OrderDetails>();

            foreach (var cart in shoppingCart)
            {
                orderDetails.Add(new OrderDetails()
                {
                    OrderId = order.OrderId,
                    ProductId = cart.ProductId,
                    IsCompleted = false,
                    Quantity = cart.Quantity,
                    PricePerItem = (dailyDeal?.ProductId == cart.ProductId) ? dailyDeal.NewPrice : cart.Product.Price
                });
            }

            db.OrderDetails.AddRange(orderDetails);

            db.ShoppingCarts.RemoveRange(shoppingCart);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
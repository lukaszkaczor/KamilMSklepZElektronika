using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ElectronicsShop.Models;
using ElectronicsShop.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(bool errorMsg = false)
        {
            var user = User.Identity.GetUserId();

            var carts = db.ShoppingCarts
                .Include(d => d.Product).ToList();

            var products = db.Products
                .Include(d => d.Brand)
                .Include(d => d.Gallery.ImageGalleries)
                .ToList();

            var model = new List<ShoppingCartViewModel>();

            var dailyDeal = db.DailyDeals.FirstOrDefault(d => d.Start < DateTime.Now && d.End > DateTime.Now);

            foreach (var shoppingCart in carts)
            {
                var product = products.FirstOrDefault(d => d.Id == shoppingCart.ProductId);

                if (dailyDeal?.ProductId == shoppingCart.ProductId)
                {
                    product.Price = dailyDeal.NewPrice;
                }

                model.Add(new ShoppingCartViewModel()
                {
                    Product = product,
                    Quantity = shoppingCart.Quantity
                });
            }

            if (errorMsg) ViewBag.ErrorMsg = "Podana ilość nie jest dostępna w magazynie";
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(int productId, int quantity)
        {
            var userId = User.Identity.GetUserId();
            var productExists = db.Products.Any(d => d.Id == productId);
            if (!productExists) return HttpNotFound();

            var itemsCount = db.Products.FirstOrDefault(d => d.Id == productId)?.QuantityInStock ?? 0;


            if (itemsCount >= quantity)
            {
                var alreadyInCart = db.ShoppingCarts.Where(d => d.ApplicationUserId == userId)
                    .FirstOrDefault(d => d.ProductId == productId);

                if (alreadyInCart == null)
                {
                    db.ShoppingCarts.Add(new ShoppingCart()
                    {
                        ApplicationUserId = userId,
                        ProductId = productId,
                        Quantity = quantity
                    });
                }
                else
                {
                    alreadyInCart.Quantity += quantity;
                }
            }

            db.SaveChanges();

            return RedirectToAction("Details", "Products",
                new { id = productId, quantityError = (itemsCount < quantity), successMsg = (itemsCount >= quantity) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFromCart(int itemId)
        {
            var userId = User.Identity.GetUserId();

            var productToDelete = db.ShoppingCarts.Where(d => d.ApplicationUserId == userId)
                .FirstOrDefault(d => d.ProductId == itemId);

            if (productToDelete == null) return HttpNotFound();

            db.ShoppingCarts.Remove(productToDelete);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdjustQuantity(int productId, bool actionType)
        {
            var userId = User.Identity.GetUserId();
            var action = actionType ? 1 : -1;
            var errorMsg = false;

            var product = db.Products.FirstOrDefault(d => d.Id == productId);

            var itemToUpdate = db.ShoppingCarts.Where(d => d.ApplicationUserId == userId)
                .SingleOrDefault(d => d.ProductId == productId);

            if (itemToUpdate == null || product == null) return HttpNotFound();

            if ((itemToUpdate.Quantity += action) == 0)
            {
                db.ShoppingCarts.Remove(itemToUpdate);
            }
            else if ((itemToUpdate.Quantity += action) > product.QuantityInStock)
            {
                errorMsg = true;
            }
            else
            {
                itemToUpdate.Quantity += action;
            }
            db.SaveChanges();
            return RedirectToAction("Index", new { errorMsg = errorMsg });
        }
    }
}
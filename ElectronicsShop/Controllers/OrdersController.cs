using System.Collections.Generic;
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

            var shoppingCart = db.ShoppingCarts.Where(d => d.ApplicationUserId == userId);

            foreach (var item in shoppingCart)
            {
                //totalPrice += item.
            }

            return View();
        }

        public ActionResult ManageOrder()
        {
            return View(new ManageOrderViewModel());
        }

        public ActionResult OrderProcessing()
        {
            return View(new List<Order>());
        }
    }
}
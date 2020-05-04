using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ElectronicsShop.Models;
using ElectronicsShop.Models.DbModels;
using ElectronicsShop.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace ElectronicsShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersManagementController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET
        public ActionResult Index()
        {
            var model = db.Orders.Where(d => d.EmployeeId == null).ToList();

            return View(model);
        }

        public ActionResult ManageOrder(int id)
        {
            var userId = User.Identity.GetUserId();
            var order = db.Orders.Include(d => d.Address).FirstOrDefault(d => d.OrderId == id);

            order.EmployeeId = userId;
            order.OrderStatus = OrderStatus.Accepted;
            db.SaveChanges();

            var orderDetails = new List<OrderDetails>();

            orderDetails = db.OrderDetails.Include(d => d.Product.Brand).Where(d => d.OrderId == id).ToList();

            var model = new ManageOrderViewModel()
            {
                Order = order,
                OrderDetails = orderDetails
            };


            return View(model);
        }

        public ActionResult ChangeStatus(int orderDetailsId)
        {
            var orderDetails = db.OrderDetails.Include(d => d.Order).FirstOrDefault(d => d.OrderDetailsId == orderDetailsId);

            orderDetails.IsCompleted = !orderDetails.IsCompleted;
            db.SaveChanges();

            return RedirectToAction("ManageOrder", new { id = orderDetails.Order.OrderId });
        }

        public ActionResult History()
        {
            var userId = User.Identity.GetUserId();

            var model = new List<Order>();

            model = db.Orders
                .Where(d => d.EmployeeId == userId)
                .Where(d => d.OrderStatus != OrderStatus.Created && d.OrderStatus != OrderStatus.Accepted).ToList();

            return View(model);
        }

        public ActionResult SetStatusToCompleted(int orderId)
        {
            var order = db.Orders.Find(orderId);
            var orderDetails = db.OrderDetails.Where(d => d.OrderId == orderId);

            if (!orderDetails.All(d => d.IsCompleted))
                return HttpNotFound();


            order.OrderStatus = OrderStatus.Completed;
            db.SaveChanges();

            return RedirectToAction("History");
        }

        public ActionResult SetStatusToCancelled(int orderId)
        {
            var order = db.Orders.Find(orderId);

            order.OrderStatus = OrderStatus.Cancelled;
            db.SaveChanges();

            return RedirectToAction("History");
        }

        public ActionResult ActiveOrders()
        {
            var userId = User.Identity.GetUserId();

            var model = db.Orders.Where(d => d.EmployeeId == userId)
                .Where(d => d.OrderStatus == OrderStatus.Accepted).ToList();

            return View(model);
        }
    }
}
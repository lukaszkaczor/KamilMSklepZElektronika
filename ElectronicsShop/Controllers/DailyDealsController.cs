using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectronicsShop.Models;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.Controllers
{
    public class DailyDealsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DailyDeals
        public ActionResult Index()
        {
            var dailyDeals = db.DailyDeals.Include(d => d.Product);
            return View(dailyDeals.ToList());
        }

        // GET: DailyDeals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyDeal dailyDeal = db.DailyDeals.Find(id);
            if (dailyDeal == null)
            {
                return HttpNotFound();
            }
            return View(dailyDeal);
        }

        // GET: DailyDeals/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: DailyDeals/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DailyDealId,ProductId,NewPrice,Quantity,ItemsSold,Start,End,Ended")] DailyDeal dailyDeal)
        {
            if (ModelState.IsValid)
            {
                db.DailyDeals.Add(dailyDeal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", dailyDeal.ProductId);
            return View(dailyDeal);
        }

        // GET: DailyDeals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyDeal dailyDeal = db.DailyDeals.Find(id);
            if (dailyDeal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", dailyDeal.ProductId);
            return View(dailyDeal);
        }

        // POST: DailyDeals/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DailyDealId,ProductId,NewPrice,Quantity,ItemsSold,Start,End,Ended")] DailyDeal dailyDeal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyDeal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", dailyDeal.ProductId);
            return View(dailyDeal);
        }

        // GET: DailyDeals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyDeal dailyDeal = db.DailyDeals.Find(id);
            if (dailyDeal == null)
            {
                return HttpNotFound();
            }
            return View(dailyDeal);
        }

        // POST: DailyDeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyDeal dailyDeal = db.DailyDeals.Find(id);
            db.DailyDeals.Remove(dailyDeal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

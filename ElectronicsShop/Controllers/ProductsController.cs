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
using ElectronicsShop.ViewModels;

namespace ElectronicsShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Gallery);
            return View(products.ToList());
        }

        public ActionResult Test()
        {
            return View();
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products
                .Include(d => d.Brand)
                .Include(d => d.Category.Section)
                .FirstOrDefault(d => d.Id == id);

            var model = new ProductDetailsViewModel()
            {
                Product = product,
                Tags = TagManager.GetTagNameWithValues(db, product)
            };

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,IsRecommended,QuantityInStock,BrandId,CategoryId,GalleryId")] Product product)
        {
            if (!ModelState.IsValid || product.BrandId == 0 || product.CategoryId == 0)
            {
                ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
                ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
                ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", product.GalleryId);

                if (product.BrandId == 0)
                {
                    ModelState.AddModelError("", "Wybierz właściwą markę");
                }

                if (product.CategoryId == 0)
                {
                    ModelState.AddModelError("", "Wybierz właściwą kategorię");
                }

                return View(product);
            }

            db.Products.Add(product);
            db.SaveChanges();

            var hasGallery = false;

            if (product.GalleryId > 0)
            {
                hasGallery = true;
            }

            return RedirectToAction("SetTags", new { id = product.Id, hasGallery });

            //if (product.GalleryId == 0)
            //{
            //    return RedirectToAction("Create", "Galleries")
            //}

            return RedirectToAction("Details", new { id = product.Id });
            //if (ModelState.IsValid)
            //{
            //    db.Products.Add(product);
            //    db.SaveChanges();

            //    //if (product.GalleryId == 0)
            //    //{
            //    //    return RedirectToAction("Create", "Galleries")
            //    //}

            //    return RedirectToAction("Details", new{ id = product.Id});
            //}

            //ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            //ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", product.GalleryId);
            //return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", product.GalleryId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,IsRecommended,QuantityInStock,BrandId,CategoryId,GalleryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.GalleryId = new SelectList(db.Galleries, "Id", "Name", product.GalleryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SetTags(int id, bool hasGallery = false)
        {
            if (!db.Products.Any(d => d.Id == id) || id == 0)
            {
                return HttpNotFound();
            }

            var model = new SetTagsToProductViewModel();
            var tags = db.Tags.Include(d => d.TagValues).OrderBy(d => d.Name).ToList();
            var tagValues = db.TagValues.Where(d => d.ProductId == id).ToList();

            var list = new List<TagTransferViewModel>();

            foreach (var tag in tags)
            {
                list.Add(new TagTransferViewModel()
                {
                    TagId = tag.Id,
                    TagName = tag.Name,
                    Value = tagValues.SingleOrDefault(d => d.TagId == tag.Id)?.Value ?? String.Empty,
                    TagValueId = tagValues.SingleOrDefault(d => d.TagId == tag.Id)?.Id ?? 0,
                });

            }

            model.TagTransferModels = list.OrderBy(d => d.TagName).ToList();
            model.HasGallery = hasGallery;
            model.ProductId = id;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetTags(SetTagsToProductViewModel model)
        {
            var productTags = db.ProductTags.ToList();
            var tagValues = db.TagValues.Where(d => d.ProductId == model.ProductId);

            foreach (var tag in model.TagTransferModels)
            {
                var tagValue = new TagValue()
                {
                    ProductId = model.ProductId,
                    TagId = tag.TagId,
                    Value = tag.Value,
                    Id = tag.TagValueId
                };

                var value = tagValues.Where(d => d.TagId == tagValue.TagId).SingleOrDefault(d => d.ProductId == tagValue.ProductId);

                if (String.IsNullOrWhiteSpace(tag.Value))
                {
                    var tagValueToDelete = tagValues.Where(d => d.TagId == tagValue.TagId).SingleOrDefault(d => d.Id == tagValue.Id);
                    var productTagToDelete = productTags.Where(d => d.TagId == tagValue.TagId).SingleOrDefault(d => d.ProductId == tagValue.ProductId);

                    if (tagValueToDelete != null)
                        db.TagValues.Remove(tagValueToDelete);

                    if (productTagToDelete != null)
                        db.ProductTags.Remove(productTagToDelete);

                    db.SaveChanges();
                    continue;
                }

                if (!tagValues.Any(d => d.Id == tagValue.Id))
                {
                    db.TagValues.Add(tagValue);

                    db.ProductTags.Add(new ProductTags()
                    {
                        ProductId = tagValue.ProductId,
                        TagId = tagValue.TagId
                    });
                }
                else if (value != null)
                {
                    value.Value = tagValue.Value;
                }

                db.SaveChanges();
            }

            if (db.Products.FirstOrDefault(d => d.Id == model.ProductId)?.GalleryId == null)
            {
                return RedirectToAction("SetGallery", "Products", new { id = model.ProductId });
            }

            return RedirectToAction(nameof(Details), new { id = model.ProductId });
        }

        public ActionResult SetGallery(int id)
        {
            var galleries = db.Galleries.ToList();
            var product = db.Products.FirstOrDefault(d => d.Id == id);

            var model = new SetGalleryToProductViewModel()
            {
                Galleries = galleries,
                Product = product
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetGallery(SetGalleryToProductViewModel model, string ChosenGallery)
        {
            var product = db.Products.FirstOrDefault(d => d.Id == model.Product.Id);

            if (!String.IsNullOrWhiteSpace(ChosenGallery))
            {
                product.GalleryId = Int32.Parse(ChosenGallery);
                db.SaveChanges();
            }
            else
            {
                product.GalleryId = null;
                db.SaveChanges();

            }

            return RedirectToAction("Details", new { id = model.Product.Id });
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

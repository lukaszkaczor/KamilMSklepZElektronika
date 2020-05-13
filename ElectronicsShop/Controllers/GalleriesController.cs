using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ElectronicsShop.Models;
using ElectronicsShop.Models.DbModels;
using ElectronicsShop.ViewModels;

namespace ElectronicsShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GalleriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private GalleryManager _galleryManager;

        // GET: Galleries
        public ActionResult Index()
        {
            return View(db.Galleries.ToList());
        }


        // GET: Galleries/Create
        public ActionResult Create(int? id)
        {
            if (id == null) return View();

            var product = db.Products.SingleOrDefault(d => d.Id == id);

            if (product == null)
            {
                return View();
            }

            var model = new CreateGalleryViewModel()
            {
                Gallery = new Gallery()
                {
                    Name = product.Name + "_gallery"
                },
                ProductId = product.Id
            };

            return View(model);
        }

        // POST: Galleries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Galleries.Add(model.Gallery);
                db.SaveChanges();

                if (model.ProductId > 1)
                {
                    var product = db.Products.SingleOrDefault(d => d.Id == model.ProductId);
                    product.GalleryId = model.Gallery.Id;
                }

                db.SaveChanges();


                return RedirectToAction("Edit", "Galleries", new { id = model.Gallery.Id });
            }

            return View(model);
        }

        // GET: Galleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);

            var images =
                from image in db.Images
                join imgGallery in db.ImageGalleries on image.Id equals imgGallery.ImageId
                join galleries in db.Galleries on imgGallery.GalleryId equals galleries.Id
                where imgGallery.GalleryId == id
                orderby imgGallery.Order
                select image;

            var imgGalleries = db.ImageGalleries.Where(d => d.GalleryId == id).OrderBy(d => d.Order).ToList();

            var model = new GalleryViewModel()
            {
                Images = images.ToList(),
                Gallery = gallery,
                ImageGalleries = imgGalleries
            };
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery);
        }

        // GET: Galleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);

            var products = db.Products.Where(d => d.GalleryId == gallery.Id);

            foreach (var product in products)
            {
                product.GalleryId = null;
            }

            db.Galleries.Remove(gallery);
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

        public ActionResult AddImageToGallery(int id)
        {
            var editedGallery = db.Galleries.Find(id);

            if (editedGallery == null) return HttpNotFound();

            var orderValue = db.ImageGalleries.Where(d => d.GalleryId == id).Max(d => d.Order) + 1 ?? 1;

            var model = new AddImageToGalleryViewModel()
            {
                Gallery = editedGallery,
                ImageGallery = new ImageGallery()
                {
                    Order = orderValue
                }
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImageToGallery(AddImageToGalleryViewModel model, int? imageId)
        {
            var image = model.Image;


            var imageFromDb = db.Images.FirstOrDefault(d => d.Url == model.Image.Url);

            if (imageFromDb == null)
            {
                db.Images.Add(image);
                db.SaveChanges();
                imageFromDb = image;
            }

            var imgGalleryAlreadyExists = db.ImageGalleries
                .Where(d => d.GalleryId == model.Gallery.Id).Any(d => d.ImageId == imageFromDb.Id);

            if (!imgGalleryAlreadyExists)
            {
                var imgGallery = new ImageGallery()
                {
                    GalleryId = model.Gallery.Id,
                    ImageId = imageFromDb.Id,
                    Order = model.ImageGallery.Order
                };
                db.ImageGalleries.Add(imgGallery);
                db.SaveChanges();

                _galleryManager = new GalleryManager(db);

                _galleryManager.SetOrderOfImageGalleries(imgGallery);
            }

            return RedirectToAction("Edit", new { id = model.Gallery.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetPositionOfImageInGallery(int galleryId, int order, int imageId)
        {
            var thisGallery =  db.ImageGalleries.Where(d => d.GalleryId == galleryId)
                .SingleOrDefault(d => d.ImageId == imageId);

            if (thisGallery == null) return HttpNotFound();

            thisGallery.Order = order;

            _galleryManager = new GalleryManager(db);

            _galleryManager.SetOrderOfImageGalleries(thisGallery);

            return RedirectToAction("Edit", new { id = galleryId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteImageFromGallery(int galleryId, int imageId)
        {
            var galleryToDelete = db.ImageGalleries.Where(d => d.GalleryId == galleryId)
                .SingleOrDefault(d => d.ImageId == imageId);

            if (galleryToDelete == null) return HttpNotFound();

            db.ImageGalleries.Remove(galleryToDelete);
            db.SaveChanges();

            _galleryManager = new GalleryManager(db);

            _galleryManager.OrderAndSave(db.ImageGalleries.Where(d => d.GalleryId == galleryId).ToList());

            return RedirectToAction("Edit", new { id = galleryId });
        }


    }
}

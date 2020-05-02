using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.Models
{
    public class ImageManager
    {
        
         public static List<Image> GetImagesForProduct(ApplicationDbContext context, int id)
        {
            var products = context.Products.ToList();
            var imagesList =context.Images.ToList();
            var galleriesList = context.Galleries.ToList();
            var imageGalleryList = context.ImageGalleries.ToList();


            var images =
                from image in imagesList
                join imgGallery in imageGalleryList on image.Id equals imgGallery.ImageId
                join galleries in galleriesList on imgGallery.GalleryId equals galleries.Id
                join product in products on galleries.Id equals product.GalleryId
                where product.Id == id
                orderby imgGallery.Order
                select image;


            return images.ToList();
        }

        public static Image GetFirstImageForProduct(ApplicationDbContext context, int id)
        {
            var images = GetImagesForProduct(context, id);

            if (!images.Any())
            {
                images.Add(new Image()
                {
                    Url = null
                });
            }

            return images.First();
        }

        public static Image GetFirstImageForPost(ApplicationDbContext context, int id)
        {

            var products = context.Products.ToList();
            var imagesList = context.Images.ToList();
            var galleriesList = context.Galleries.ToList();
            var imageGalleryList = context.ImageGalleries.ToList();


            var images =
                from image in imagesList
                join imgGallery in imageGalleryList on image.Id equals imgGallery.ImageId
                join galleries in galleriesList on imgGallery.GalleryId equals galleries.Id
                join product in products on galleries.Id equals product.GalleryId
                where product.GalleryId == id
                orderby imgGallery.Order
                select image;

            if (!images.ToList().Any())
            {
                images.ToList().Add(new Image()
                {
                    Url = null
                });
            }

            return images.First();
        }

    }
}
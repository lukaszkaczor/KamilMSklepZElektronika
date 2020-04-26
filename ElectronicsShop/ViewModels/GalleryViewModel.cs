using System.Collections.Generic;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.ViewModels
{
    public class GalleryViewModel
    {
        public List<Image> Images { get; set; }
        public Gallery Gallery { get; set; }
        public List<ImageGallery> ImageGalleries { get; set; } 
    }
}
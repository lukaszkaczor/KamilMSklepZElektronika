using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.ViewModels
{
    public class AddImageToGalleryViewModel
    {
        public Image Image { get; set; }
        public ImageGallery ImageGallery { get; set; }
        public Gallery Gallery { get; set; }
    }
}
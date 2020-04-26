using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.ViewModels
{
    public class CreateGalleryViewModel
    {
        public Gallery Gallery { get; set; }

        public int? ProductId { get; set; }
    }
}
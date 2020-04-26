using System.Collections.Generic;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.ViewModels
{
    public class SetGalleryToProductViewModel
    {
        public Product Product { get; set; }
        public List<Gallery> Galleries { get; set; }
    }
}
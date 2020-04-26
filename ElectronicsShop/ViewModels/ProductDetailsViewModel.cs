using System.Collections.Generic;
using ElectronicsShop.Models;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public List<TagNameWithValue> Tags { get; set; }
        public List<Image> Images { get; set; }
    }
}
using System.Collections.Generic;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> Bestsellers { get; set; }
        public List<Product> Recommended { get; set; }
    }
}
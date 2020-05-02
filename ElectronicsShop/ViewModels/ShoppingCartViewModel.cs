using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
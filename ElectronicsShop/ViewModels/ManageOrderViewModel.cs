using System.Collections.Generic;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.ViewModels
{
    public class ManageOrderViewModel
    {
        public Order Order { get; set; }    
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ElectronicsShop.Models.DbModels
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DailyDeal DailyDeal { get; set; }
        public int? DailyDealId { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Models.DbModels
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double PricePerItem { get; set; }

        [Required]
        public int Quantity { get; set; }

        public bool IsCompleted { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Security.Permissions;

namespace ElectronicsShop.Models.DbModels
{
    public class DailyDeal
    {
        public int DailyDealId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [DataType(DataType.Currency)]
        public decimal NewPrice { get; set; }

        public int Quantity { get; set; }
        public int ItemsSold { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool Ended { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ElectronicsShop.Models.DbModels;

namespace ElectronicsShop.ViewModels
{
    public class OrderSummaryViewModel
    {
        public Address Address { get; set; }
        //public Order Order { get; set; }
        public string Message { get; set; }
    }
}
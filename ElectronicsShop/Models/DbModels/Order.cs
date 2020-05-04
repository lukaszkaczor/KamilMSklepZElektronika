using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ElectronicsShop.Models.DbModels
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required] public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }

        [DataType(DataType.Currency)] public decimal TotalPrice { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public string Message { get; set; }


        public string EmployeeId { get; set; }
        public virtual ApplicationUser Employee { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
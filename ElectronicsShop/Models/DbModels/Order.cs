using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ElectronicsShop.Models.DbModels
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }

        [DataType(DataType.Currency)]
        public double TotalPrice { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public string Message { get; set; }

        //[Required(ErrorMessage = DatabaseErrorMessage.FieldRequired)]
        //public int ShippingMethodId { get; set; }
        //public ShippingMethod ShippingMethod { get; set; }

        //[Required(ErrorMessage = DatabaseErrorMessage.FieldRequired)]
        //public int PayingMethodId { get; set; }
        //public PayingMethod PayingMethod { get; set; }

        //public virtual IdentityUser Employee { get; set; }
        //public string EmployeeId { get; set; }

        //public virtual ICollection<OrderDetailsOrder> OrderDetailsOrder { get; set; }
    }
}
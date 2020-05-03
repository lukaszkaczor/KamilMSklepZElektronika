using Microsoft.AspNet.Identity.EntityFramework;

namespace ElectronicsShop.Models.DbModels
{
    public class Address
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
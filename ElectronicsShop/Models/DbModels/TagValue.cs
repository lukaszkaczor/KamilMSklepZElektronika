using System.ComponentModel.DataAnnotations;
using ElectronicsShop.Models.Interfaces;

namespace ElectronicsShop.Models.DbModels
{
    public class TagValue 
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
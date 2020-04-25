using System.ComponentModel.DataAnnotations;
using ElectronicsShop.Models.Interfaces;

namespace ElectronicsShop.Models.DbModels
{
    public class Category : IModelBase
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
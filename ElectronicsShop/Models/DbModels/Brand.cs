using ElectronicsShop.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Models.DbModels
{
    public class Brand : IModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Image Image { get; set; }
        [Required]
        public int ImageId { get; set; }
    }
}
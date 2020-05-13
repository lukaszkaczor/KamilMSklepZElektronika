using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElectronicsShop.Models.Interfaces;
using Newtonsoft.Json;

namespace ElectronicsShop.Models.DbModels
{
    public class Product : IModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public bool IsRecommended { get; set; } = false;

        public int QuantityInStock { get; set; }

        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [Required] 
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Gallery Gallery { get; set; }
        public int? GalleryId { get; set; }

        public virtual ICollection<ProductTags> ProductTags { get; set; }
    }
}
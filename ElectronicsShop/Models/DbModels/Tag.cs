using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElectronicsShop.Models.Interfaces;

namespace ElectronicsShop.Models.DbModels
{
    public class Tag : IModelBase
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public ICollection<TagValue> TagValues { get; set; }

        public virtual ICollection<ProductTags> ProductTags { get; set; }
    }
}
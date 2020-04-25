using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElectronicsShop.Models.Interfaces;

namespace ElectronicsShop.Models.DbModels
{
    public class Gallery : IModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ImageGallery> ImageGalleries { get; set; }

    }
}
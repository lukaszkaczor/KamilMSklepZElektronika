using System.Collections.Generic;
using ElectronicsShop.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Models.DbModels
{
    public class Image : IModelBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Url { get; set; }


        public virtual ICollection<ImageGallery> ImageGalleries { get; set; }

    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElectronicsShop.Models.Interfaces;

namespace ElectronicsShop.Models.DbModels
{
    public class Section : IModelBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
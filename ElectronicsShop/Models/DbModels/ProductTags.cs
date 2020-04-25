using System.ComponentModel.DataAnnotations;

namespace ElectronicsShop.Models.DbModels
{
    public class ProductTags
    {
        [Key]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        [Key]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
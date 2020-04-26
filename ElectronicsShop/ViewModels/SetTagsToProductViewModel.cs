using System.Collections.Generic;

namespace ElectronicsShop.ViewModels
{
    public class SetTagsToProductViewModel
    {
        public List<TagTransferViewModel> TagTransferModels { get; set; }

        public int ProductId { get; set; }
        public bool HasGallery { get; set; } 
    }
}
using System.Collections.Generic;

namespace ElectronicsShop.Models
{
    public class ControllerWithLabel
    {
        public string ControllerName { get; set; }
        public string Label { get; set; }
        public MenuType MenuType { get; set; } = MenuType.Lower;
    }
}
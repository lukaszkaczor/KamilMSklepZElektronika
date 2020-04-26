using System.Collections.Generic;

namespace ElectronicsShop.Models
{
    public static class ControllersInAdminMenu
    {
        public static ControllerWithLabel[] GetControllers { get; set; } = new ControllerWithLabel[]
        {
            ControllerList.Brands,
            ControllerList.Sections,
            ControllerList.Categories,
            ControllerList.Products,
            ControllerList.Tags,
            ControllerList.Images,
            ControllerList.Galleries
        };

        //public static List<ControllerWithLabel> GetControllers { get; set; } = new List<ControllerWithLabel>()
        //{
        //    ControllerList.Brands,
        //    ControllerList.Categories,
        //    ControllerList.Products,
        //    ControllerList.Tags,
        //    ControllerList.Images,
        //    ControllerList.Galleries
        //};
    }
}
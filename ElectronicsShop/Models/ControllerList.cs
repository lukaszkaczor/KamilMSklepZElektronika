using System.Collections.Generic;

namespace ElectronicsShop.Models
{
    public static class ControllerList
    {
        public static ControllerWithLabel Brands { get; } = new ControllerWithLabel()
        {
            ControllerName = "Brands",
            Label = "Marki"
        };

        public static ControllerWithLabel Categories { get;  } = new ControllerWithLabel()
        {
            ControllerName = "Categories",
            Label = "Kategorie"
        };

        public static ControllerWithLabel Products { get; } = new ControllerWithLabel()
        {
            ControllerName = "Products",
            Label = "Produkty"
        };

        public static ControllerWithLabel Tags { get; } = new ControllerWithLabel()
        {
            ControllerName = "Tags",
            Label = "Tagi"
        };

        public static ControllerWithLabel Images { get; } = new ControllerWithLabel()
        {
            ControllerName = "Images",
            Label = "Zdjęcia"
        };

        public static ControllerWithLabel Galleries { get; } = new ControllerWithLabel()
        {
            ControllerName = "Galleries",
            Label = "Galerie"
        };

        public static ControllerWithLabel Sections { get; } = new ControllerWithLabel()
        {
            ControllerName = "Sections",
            Label = "Sekcje"
        };




        //public static List<ControllerWithLabel> ControllerWithLabels { get;} = new List<ControllerWithLabel>()
        //{
        //    //new ControllerWithLabel()
        //    //{
        //    //    ControllerName = "Brands",
        //    //    Label = "Marki"
        //    //},            new ControllerWithLabel()
        //    //{
        //    //    ControllerName = "Categories",
        //    //    Label = "Kategorie"
        //    //},            new ControllerWithLabel()
        //    //{
        //    //    ControllerName = "Products",
        //    //    Label = "Przedmioty"
        //    //},
        //    //new ControllerWithLabel()
        //    //{
        //    //    ControllerName = "Tags",
        //    //    Label = "Tagi"
        //    //}
        //};
    }
}
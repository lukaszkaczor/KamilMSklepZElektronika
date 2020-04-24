
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ElectronicsShop.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ElectronicsShop.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}
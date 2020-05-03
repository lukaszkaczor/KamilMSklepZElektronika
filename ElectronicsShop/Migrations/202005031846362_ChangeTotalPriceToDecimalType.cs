namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTotalPriceToDecimalType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
        }
    }
}

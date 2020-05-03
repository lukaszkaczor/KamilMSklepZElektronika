namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePricePerItemToDecimalType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "PricePerItem", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "PricePerItem", c => c.Double(nullable: false));
        }
    }
}

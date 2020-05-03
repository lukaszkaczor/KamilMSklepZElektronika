namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDailyDealTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyDeals",
                c => new
                    {
                        DailyDealId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        NewPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        ItemsSold = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Ended = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DailyDealId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.ShoppingCarts", "DailyDealId", c => c.Int());
            CreateIndex("dbo.ShoppingCarts", "DailyDealId");
            AddForeignKey("dbo.ShoppingCarts", "DailyDealId", "dbo.DailyDeals", "DailyDealId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "DailyDealId", "dbo.DailyDeals");
            DropForeignKey("dbo.DailyDeals", "ProductId", "dbo.Products");
            DropIndex("dbo.ShoppingCarts", new[] { "DailyDealId" });
            DropIndex("dbo.DailyDeals", new[] { "ProductId" });
            DropColumn("dbo.ShoppingCarts", "DailyDealId");
            DropTable("dbo.DailyDeals");
        }
    }
}

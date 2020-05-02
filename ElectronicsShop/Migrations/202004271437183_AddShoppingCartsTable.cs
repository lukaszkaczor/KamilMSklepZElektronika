namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoppingCartsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ShoppingCarts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "ProductId" });
            DropIndex("dbo.ShoppingCarts", new[] { "ApplicationUserId" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}

namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductIdToTagValuesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TagValues", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.TagValues", "ProductId");
            AddForeignKey("dbo.TagValues", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagValues", "ProductId", "dbo.Products");
            DropIndex("dbo.TagValues", new[] { "ProductId" });
            DropColumn("dbo.TagValues", "ProductId");
        }
    }
}

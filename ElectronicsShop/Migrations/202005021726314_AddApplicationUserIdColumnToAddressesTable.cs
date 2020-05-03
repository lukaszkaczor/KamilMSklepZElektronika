namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserIdColumnToAddressesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Addresses", "ApplicationUserId");
            AddForeignKey("dbo.Addresses", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Addresses", new[] { "ApplicationUserId" });
            DropColumn("dbo.Addresses", "ApplicationUserId");
        }
    }
}

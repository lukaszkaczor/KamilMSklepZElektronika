namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeIdToOrdersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "EmployeeId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "EmployeeId");
            AddForeignKey("dbo.Orders", "EmployeeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropColumn("dbo.Orders", "EmployeeId");
        }
    }
}

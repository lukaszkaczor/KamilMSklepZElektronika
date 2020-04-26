namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSectionsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "SectionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "SectionId");
            AddForeignKey("dbo.Categories", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "SectionId", "dbo.Sections");
            DropIndex("dbo.Categories", new[] { "SectionId" });
            DropColumn("dbo.Categories", "SectionId");
            DropTable("dbo.Sections");
        }
    }
}

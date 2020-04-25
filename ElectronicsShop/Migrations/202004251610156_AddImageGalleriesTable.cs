namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageGalleriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageGalleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        Order = c.Int(),
                    })
                .PrimaryKey(t => new { t.GalleryId, t.ImageId })
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.GalleryId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageGalleries", "ImageId", "dbo.Images");
            DropForeignKey("dbo.ImageGalleries", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.ImageGalleries", new[] { "ImageId" });
            DropIndex("dbo.ImageGalleries", new[] { "GalleryId" });
            DropTable("dbo.Galleries");
            DropTable("dbo.ImageGalleries");
        }
    }
}

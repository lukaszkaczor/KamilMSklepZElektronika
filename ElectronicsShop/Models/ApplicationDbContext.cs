using ElectronicsShop.Models.DbModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.AccessControl;
using ElectronicsShop.Models.Interfaces;

namespace ElectronicsShop.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<ImageGallery> ImageGalleries { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagValue> TagValues { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTags> ProductTags { get; set; }    
        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageGallery>()
                .HasKey(c => new {c.GalleryId, c.ImageId});

            
            modelBuilder.Entity<ProductTags>()
                .HasKey(c => new {c.ProductId, c.TagId});

            base.OnModelCreating(modelBuilder);
        }
    }
}
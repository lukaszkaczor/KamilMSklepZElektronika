namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"  
               INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3d35a60d-f524-4706-8db5-7407a7ccec11', N'admin@omega.pl', 0, N'AAvdCR/sH5hUk6bbrUQ8C68M1jZgbmEOEqTkrBZI6EmTDlxPKISf9Cm37yEHpfxj4w==', N'2cc2338c-cec1-472b-9328-f4e6111fe124', NULL, 0, 0, NULL, 1, 0, N'admin@omega.pl')
               INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'be54a320-81ab-41d3-a035-52c5283c3236', N'Admin')
               INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3d35a60d-f524-4706-8db5-7407a7ccec11', N'be54a320-81ab-41d3-a035-52c5283c3236')
            ");
        }

        public override void Down()
        {
        }
    }
}

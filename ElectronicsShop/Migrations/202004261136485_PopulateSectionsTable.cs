namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateSectionsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Sections] ON
                INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (1, N'Diody')
                INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (2, N'Mikrokontrolery')
                INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (3, N'Przewody')
                INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (4, N'Uk³ady scalone')
                INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (5, N'Konwertery')
                INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (6, N'Akcesoria samochodowe')
                INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (7, N'Regulatory napiêæ')
                INSERT INTO [dbo].[Sections] ([Id], [Name]) VALUES (8, N'Ró¿ne')
                SET IDENTITY_INSERT [dbo].[Sections] OFF
            ");
        }

        public override void Down()
        {
        }
    }
}

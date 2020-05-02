namespace ElectronicsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Categories] ON
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (1, N'Diody LED i akcesoria', 1)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (2, N'Diody prostownicze', 1)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (3, N'Diody Schottky''ego', 1)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (4, N'Diody Zenera', 1)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (5, N'Kontrolki', 1)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (6, N'AVR', 2)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (7, N'NXP', 2)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (8, N'STM32', 2)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (9, N'Przewody USB', 3)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (10, N'Przewody i z³¹cza audio', 3)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (11, N'Przewody i z³¹cza wideo', 3)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (12, N'Przewody po³¹czeniowe', 3)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (13, N'Przewody pomiarowe', 3)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (14, N'Enkodery', 4)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (15, N'Interfejsy', 4)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (16, N'Komparatory', 4)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (17, N'£adowarki', 4)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (18, N'Mostki prostownicze', 4)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (19, N'Przetworniki', 4)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (20, N'Konwertery Napiêæ', 5)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (21, N'Konwertery USB - UART / RS232 / RS485', 5)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (22, N'Ekspandery wyprowadzeñ', 5)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (23, N'Przetworniki A/C i C/A', 5)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (24, N'Alkomaty', 6)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (25, N'Bezpieczniki samochodowe', 6)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (26, N'Lokalizatory GPS', 6)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (27, N'£adowarki samochodowe', 6)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (28, N'Uchwyty', 6)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (29, N'Przetwornice step-up', 7)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (30, N'Przetwornice step-up / step-down', 7)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (31, N'Stabilizatory liniowe', 7)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (32, N'Transformatory', 7)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (33, N'Akcesoria do akumulatorów', 8)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (34, N'Baterie', 8)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (35, N'Panele s³oneczne', 8)
                INSERT INTO [dbo].[Categories] ([Id], [Name], [SectionId]) VALUES (36, N'Powerbanki', 8)
                SET IDENTITY_INSERT [dbo].[Categories] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}

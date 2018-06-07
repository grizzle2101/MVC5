namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    //Section 8 - Tutorial 7 - Seeding User Data
    //Task 4 - Add Migration Script
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2c476e02-19a5-48bf-b4b2-323121dc0a7b', N'guest@vidly.com', 0, N'AKigC3yIzJ72VL0EK+e8yOYqyhn9wOigUt1PEuESRzP8GQdhmzU/j6Uk2NPB8i5Mcg==', N'ddd6cba8-cbf8-467c-b078-ea0bbef0822b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'664cab00-055f-45b9-8cfa-4ca7e21dd35e', N'admin@vidly.com', 0, N'AMLH663v43+jGcFeP4PwJm2+rvwSAta0gjhHpxdQLTdtvbY7MfObW9GmdCgqqsssbQ==', N'7eaabaeb-27e3-434e-9ac8-be6420123614', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'596603fd-9838-448e-abfd-f2eec7584c1c', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'664cab00-055f-45b9-8cfa-4ca7e21dd35e', N'596603fd-9838-448e-abfd-f2eec7584c1c')
                ");
        }
        
        public override void Down()
        {
        }
    }
}

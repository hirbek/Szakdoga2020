namespace Szakdoga.Migrations
{
    using System;
    using Szakdoga.Models;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [TeljesNev], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f4eccb08-5fa9-444f-8a7d-2755e5de2117', N'Admin Admin', N'admin@admin.com', 0, N'AKvOJsYyQNONrsKv0xqNaM9ToR0zFuW8fO1jlMq5uIIf2r6CDFhoaWMGZERC4xUFsg==', N'264b536e-a83d-40ac-989d-7702075b78c8', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')");
            Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd01255f0-ce2f-4ffd-9a77-9a04aac85165', N'{RoleNevek.Admin}')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f4eccb08-5fa9-444f-8a7d-2755e5de2117', N'd01255f0-ce2f-4ffd-9a77-9a04aac85165')");
        }
        
        public override void Down()
        {
        }
    }
}

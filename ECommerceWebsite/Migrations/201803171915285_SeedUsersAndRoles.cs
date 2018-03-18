namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Active]) VALUES (N'12ebc121-8250-4abb-95fe-28d3cb086eee', N'user1@acme.com', 0, N'AN5IoLbvlbOboyUM8DszNs5F11dDWhFAqgs+OMJ53AnIblbCezZgaahE+QoG6cK6Pw==', N'6d87a3a5-5187-499b-9bbd-74768d6c28cd', NULL, 0, 0, NULL, 1, 0, N'user1@acme.com', 1)
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Active]) VALUES (N'22941b39-c37a-4cbb-b85e-8f7fa9196b1b', N'admin@acme.com', 0, N'AHjK6evV27u1wIP/NuCgBCeV+BZeo7aYmkMttrgaZ6JmSfzaD+OLURx9JDdjA0gFKw==', N'f6aa39ba-5872-44fa-b461-8941015528ba', NULL, 0, 0, NULL, 1, 0, N'admin@acme.com', 1)
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Active]) VALUES (N'b12ec413-593a-402d-b968-1b95a71a274d', N'user2@acme.com', 0, N'AFiVJhZSxARPPYmktnZBLHtcc45fbyTtLbtPTuor9YxzHmztYdcjMSOpwRUJJBEG5Q==', N'b2ab0761-bee4-4275-b871-32b4cff5522a', NULL, 0, 0, NULL, 1, 0, N'user2@acme.com', 1)

                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c9e834d6-14ea-40db-9c31-323c689af7e4', N'Admin')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'866098df-a4b1-4d54-8818-f883a40e350f', N'User')

                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'12ebc121-8250-4abb-95fe-28d3cb086eee', N'866098df-a4b1-4d54-8818-f883a40e350f')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b12ec413-593a-402d-b968-1b95a71a274d', N'866098df-a4b1-4d54-8818-f883a40e350f')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22941b39-c37a-4cbb-b85e-8f7fa9196b1b', N'c9e834d6-14ea-40db-9c31-323c689af7e4')"
            );
        }

        public override void Down()
        {
        }
    }
}

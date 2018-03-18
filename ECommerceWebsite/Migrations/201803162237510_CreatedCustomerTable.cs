namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedCustomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        UserProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "UserProfile_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "UserProfile_Id" });
            DropTable("dbo.Customers");
        }
    }
}

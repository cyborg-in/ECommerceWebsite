namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuantityAndSubtotalToOrders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "SubTotal", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "SubTotal");
            DropColumn("dbo.Orders", "Quantity");
        }
    }
}

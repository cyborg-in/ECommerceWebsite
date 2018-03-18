namespace ECommerceWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedOrderNumberIndexToOrders : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Orders", "OrderNumber");
        }

        public override void Down()
        {
            DropIndex("dbo.Orders", "OrderNumber");
        }
    }
}

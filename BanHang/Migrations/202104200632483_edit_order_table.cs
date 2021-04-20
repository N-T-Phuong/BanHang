namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_order_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderDate");
        }
    }
}

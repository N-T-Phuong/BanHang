namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_order : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Total", c => c.Int(nullable: false));
        }
    }
}

namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IdUser", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "Address", c => c.String());
            CreateIndex("dbo.Orders", "IdUser");
            AddForeignKey("dbo.Orders", "IdUser", "dbo.Users", "IdUser", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "IdUser", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "IdUser" });
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Orders", "IdUser");
        }
    }
}

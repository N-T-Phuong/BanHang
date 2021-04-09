namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        UnitPrice = c.Double(nullable: false),
                        Category_id = c.Int(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_id, cascadeDelete: true)
                .Index(t => t.Category_id);
            
            CreateTable(
                "dbo.OderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_id = c.Int(nullable: false),
                        Order_id = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Product_id)
                .Index(t => t.Order_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_id = c.Int(nullable: false),
                        Note = c.String(),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: true)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 13),
                        Address = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Logo = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OderDetails", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Orders", "User_id", "dbo.Users");
            DropForeignKey("dbo.OderDetails", "Order_id", "dbo.Orders");
            DropForeignKey("dbo.Products", "Category_id", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "User_id" });
            DropIndex("dbo.OderDetails", new[] { "Order_id" });
            DropIndex("dbo.OderDetails", new[] { "Product_id" });
            DropIndex("dbo.Products", new[] { "Category_id" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

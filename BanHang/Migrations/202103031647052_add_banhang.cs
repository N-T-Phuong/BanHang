namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_banhang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Category_id = c.Int(nullable: false),
                        Image = c.String(),
                        UnitPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Category_id, cascadeDelete: true)
                .Index(t => t.Category_id);
            
            CreateTable(
                "dbo.OderDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Product_id = c.Int(nullable: false),
                        Order_id = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.Order_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Product_id)
                .Index(t => t.Order_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        User_id = c.Int(nullable: false),
                        Status = c.String(),
                        Node = c.String(),
                        Total = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: true)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        phone = c.String(nullable: false, maxLength: 13),
                        address = c.String(),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
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
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

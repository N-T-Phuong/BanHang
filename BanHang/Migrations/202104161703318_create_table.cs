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
                        IdCategory = c.Int(nullable: false, identity: true),
                        NameCategory = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        NameProduct = c.String(nullable: false, maxLength: 50),
                        UnitPrice = c.Double(nullable: false),
                        Category_id = c.Int(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("dbo.Categories", t => t.Category_id, cascadeDelete: true)
                .Index(t => t.Category_id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        IdOrderDetail = c.Int(nullable: false, identity: true),
                        Product_id = c.Int(nullable: false),
                        IdOrder = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdOrderDetail)
                .ForeignKey("dbo.Orders", t => t.IdOrder, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.Product_id)
                .Index(t => t.IdOrder);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        IdOrder = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdOrder);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_id", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "IdOrder", "dbo.Orders");
            DropForeignKey("dbo.Products", "Category_id", "dbo.Categories");
            DropIndex("dbo.OrderDetails", new[] { "IdOrder" });
            DropIndex("dbo.OrderDetails", new[] { "Product_id" });
            DropIndex("dbo.Products", new[] { "Category_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

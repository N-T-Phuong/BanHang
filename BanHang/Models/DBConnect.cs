using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BanHang.Models
{
    public partial class DBConnect : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; } 
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public DBConnect()
            : base("name=DBConnect")
        {
            
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

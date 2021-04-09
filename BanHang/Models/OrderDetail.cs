using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    [ Table ("OderDetails")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int Product_id { get; set; }
        [ForeignKey("Product_id")]
        public virtual Product Product { get; set; }
        public int Order_id { get; set; }
        [ForeignKey("Order_id")]
        public virtual Order Order { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalOrder { get; set; }
    }
}
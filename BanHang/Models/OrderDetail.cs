using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    [ Table ("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        public int IdOrderDetail { get; set; }
        public int Product_id { get; set; }
        [ForeignKey("Product_id")]
        public virtual Product Product { get; set; }
        public int IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public virtual Order Order { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalOrder { get; set; }
    }
}
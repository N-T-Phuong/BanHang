using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int id { get; set; }
        public int User_id { get; set; }
        [ForeignKey("User_id")]
        public virtual User User { get; set; }
        public string Status { get; set; }
        public string Node { get; set; }
        public int Total { get; set; }
        public DateTime Created_at { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
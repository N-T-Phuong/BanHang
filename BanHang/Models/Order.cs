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
        public int Id { get; set; }
        public int User_id { get; set; }
        [ForeignKey("User_id")]
        public virtual User User { get; set; }
        public string Note { get; set; }
        public int Total { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
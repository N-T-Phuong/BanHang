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
        public int IdOrder { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
        public string Note { get; set; }
        //public int Total { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
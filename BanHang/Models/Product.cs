using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    [Table("Products")]
    public class Product
    {

        [Key]
        public int id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public int Category_id { get; set; }
        [ForeignKey("Category_id")]
        public virtual Category Category { get; set; }

        public string Image { get; set; }
        public int UnitPrice { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
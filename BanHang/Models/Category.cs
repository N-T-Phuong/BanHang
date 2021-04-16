using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    [Table ("Categories")]
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        [Required, MaxLength(30)]
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
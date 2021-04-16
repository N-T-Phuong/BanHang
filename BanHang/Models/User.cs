using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Required(ErrorMessage ="ConfirmPassword false")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
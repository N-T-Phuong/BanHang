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
        public int Id { get; set; }
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string ConfirmPassword { get; set; }
        [Required, MinLength(9), MaxLength(13)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
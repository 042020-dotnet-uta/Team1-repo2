using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Models
{
    public class User
    {
        [Display(Name = "User ID")]
        public int Id { get; set; }

        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email{ get; set; }

        [Display(Name = "User Username")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "User Password")]
        [Required]
        public string Password { get; set; }
    }
}

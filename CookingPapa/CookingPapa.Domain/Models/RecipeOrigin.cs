using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Models
{
    public class RecipeOrigin
    {
        [Display(Name = "Cultural Origin ID")]
        public int Id { get; set; }

        [Display(Name = "Cultural Origin Name")]
        [MinLength(0), MaxLength(32)]
        [Required]
        public string RecipeOriginName { get; set; }
    }
}

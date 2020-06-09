
using System.ComponentModel.DataAnnotations;

namespace CookingPapa.Domain.Models
{
    public class RecipeMeasurement
    {
        [Display(Name = "Unit of Measurement ID")]
        public int Id { get; set; }

        [Display(Name = "Unit of Measurement")]
        [MinLength(0), MaxLength(16)]
        [Required]
        public string RecipeMeasurementName { get; set; }
    }
}

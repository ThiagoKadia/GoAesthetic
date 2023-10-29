using System.ComponentModel.DataAnnotations;

namespace GoAetheticApi.Models.Request
{
    public class HarrisBenedictRequest
    {
        [Required]
        public int Age { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }
    }
}

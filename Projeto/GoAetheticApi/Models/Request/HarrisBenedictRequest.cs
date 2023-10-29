using System.ComponentModel.DataAnnotations;

namespace GoAetheticApi.Models.Request
{
    public class HarrisBenedictRequest
    {
        [Required]
        public int Idade { get; set; }

        [Required]
        public double Peso { get; set; }

        [Required]
        public double Altura { get; set; }
    }
}

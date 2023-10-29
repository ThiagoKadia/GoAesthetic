using System.ComponentModel.DataAnnotations;

namespace GoAetheticApi.Models.Request
{
    public class BalancaRequest
    {
        [Required]
        public string CodBalanca { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public double Peso { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GoAetheticApi.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbMarcosEvolucao")]
    public class MarcosEvolucaoViewModel
    {
        [Column("MEV_Id")]
        public int Id { get; set; }

        [Column("USR_Id")]
        public int UsuarioId { get; set; }

        [Column("MEV_Altura")]
        public double Altura { get; set; }

        [Column("MEV_Peso")]
        public double Peso { get; set; }

        [Column("MEV_NomeArquivoFoto")]
        public string? NomeArquivoFoto { get; set; }

        [Column("MEV_Data")]
        public DateTime DataInclusao { get; set; }

        [NotMapped]
        public IFormFile Arquivo { get; set; }

        [NotMapped]
        public Uri UrlArquivoStorage { get; set; }
    }
}

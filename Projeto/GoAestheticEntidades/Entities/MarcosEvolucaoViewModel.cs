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
        public int Usuario { get; set; }

        [Column("MEV_Altura")]
        public double? Altura { get; set; }

        [Column("MEV_Peso")]
        public double? Peso { get; set; }

        [Column("MEV_CaminhoFoto")]
        public string CaminhoFoto { get; set; }

        [Column("MEV_Data")]
        public DateTime? DataInclusao { get; set; }

        [NotMapped]
        public IFormFile Arquivo { get; set; }

        [NotMapped]
        public string ArquivoBase64 { get; set; }
    }
}

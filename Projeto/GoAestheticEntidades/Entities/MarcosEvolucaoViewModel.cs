using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbMarcosEvolucao")]
    public class MarcosEvolucaoViewModel
    {
        [Column("MEV_Id")]
        public int Id { get; set; }

        [Column("USR_Id")]
        public UsuariosViewModel Usuario { get; set; }

        [Column("MEV_Altura")]
        public double? Altura { get; set; }

        [Column("MEV_Peso")]
        public double? Peso { get; set; }

        [Column("MEV_CAminhoFoto")]
        public string CaminhoFoto { get; set; }

        [Column("MEV_Data")]
        public DateTime? DataInclusao { get; set; }
    }
}

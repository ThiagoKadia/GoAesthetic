using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double? Altura { get; set; }

        [Column("MEV_Peso")]
        public double? Peso { get; set; }

        [Column("MEV_CAminhoFoto")]
        public string? CaminhoFoto { get; set; }

        [Column("MEV_Data")]
        public DateTime? DataInclusao { get; set; }
    }
}

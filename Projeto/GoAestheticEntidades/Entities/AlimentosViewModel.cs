using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticEntidades.Entities
{
    [Table("tbAlimentos")]
    public class AlimentosViewModel
    {
        [Column("ALM_Id")]
        public int Id { get; set; }

        [Column("IFA_Id")]
        public int GrupoAlimentoId { get; set; }

        [Column("ALM_Quantidade")]
        public double? Quantidade { get; set; }
    }
}

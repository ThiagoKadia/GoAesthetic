using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticEntidades.Entities
{
    [Table("tbGrupoAlimentos")]
    public class GrupoAlimentoViewModel
    {
        [Column("GAL_Id")]
        public int Id { get; set; }

        [Column("GAL_Nome")]
        public string? Nome { get; set; }
    }
}

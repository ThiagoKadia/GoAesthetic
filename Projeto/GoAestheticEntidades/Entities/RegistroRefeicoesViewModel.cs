using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticEntidades.Entities
{
    [Table("tbRegistroRefeicoes")]
    public class RegistroRefeicoesViewModel
    {
        [Column("RRF_Id")]
        public int Id { get; set; }

        [Column("USR_Id")]
        public UsuariosViewModel? Usuario { get; set; }

        [Column("RRF_Nome")]
        public string Nome { get; set; }

        [Column("RRF_Data")]
        public DateTime? DataInclusao { get; set; }
    }
}

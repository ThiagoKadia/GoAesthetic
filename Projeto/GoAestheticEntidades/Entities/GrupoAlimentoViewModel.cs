using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbGrupoAlimentos")]
    public class GrupoAlimentoViewModel
    {
        [Column("GAL_Id")]
        public int Id { get; set; }

        [Column("GAL_Nome")]
        public string Nome { get; set; }
    }
}

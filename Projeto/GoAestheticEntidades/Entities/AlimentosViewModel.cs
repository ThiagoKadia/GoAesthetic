using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbAlimentos")]
    public class AlimentosViewModel
    {
        [Column("ALM_Id")]
        public int Id { get; set; }

        [Column("IFA_Id")]
        public GrupoAlimentoViewModel GrupoAlimento { get; set; }

        [Column("ALM_Quantidade")]
        public double? Quantidade { get; set; }
    }
}

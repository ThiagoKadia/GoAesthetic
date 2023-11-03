using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbAlimentos")]
    public class AlimentosViewModel
    {
        [Column("ALM_Id")]
        public int Id { get; set; }

        [Column("IFA_Id")]
        public int InformacaoAlimentoId { get; set; }

        [Column("RRF_Id")]
        public int RegistroRefeicaoId { get; set; }

        [Column("ALM_Quantidade")]
        public double Quantidade { get; set; }
    }
}

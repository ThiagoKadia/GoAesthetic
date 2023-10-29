using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbInformacoesAlimentos")]
    public class InformacoesAlimentosViewModel
    {
        [Column("IFA_Id")]
        public int Id { get; set; }

        [Column("GAL_Id")]
        public GrupoAlimentoViewModel GrupoAlimento { get; set; }

        [Column("IFA_Nome")]
        public string Nome { get; set; }

        [Column("IFA_Energia")]
        public double? Energia { get; set; }

        [Column("IFA_Proteina")]
        public double? Proteina { get; set; }

        [Column("IFA_Lipideos")]
        public double? Lipideos { get; set; }

        [Column("IFA_Colasterol")]
        public double? Colasterol { get; set; }

        [Column("IFA_Carboidrato")]
        public double? Carboidratos { get; set; }

        [Column("IFA_FibraAlimentar")]
        public double? FibraAlimentar { get; set; }

        [Column("IFA_Ferro")]
        public double? Ferro { get; set; }

        [Column("IFA_Sodio")]
        public double? Sodio { get; set; }

        [Column("IFA_VitaminaC")]
        public double? VitaminaC { get; set; }
    }
}

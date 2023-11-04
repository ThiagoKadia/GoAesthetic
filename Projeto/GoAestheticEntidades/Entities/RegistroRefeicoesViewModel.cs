using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbRegistroRefeicoes")]
    public class RegistroRefeicoesViewModel
    {
        [Column("RRF_Id")]
        public int Id { get; set; }

        [Column("USR_Id")]
        public int UsuarioId { get; set; }

        [Column("RRF_Nome")]
        public string Nome { get; set; }

        [Column("RRF_Data")]
        public DateTime DataInclusao { get; set; }

        [NotMapped]
        public List<AlimentosViewModel> AlimentosAssociados { get; set; }

        [NotMapped]
        public double TotalQuantidade { get; set; }

        [NotMapped]
        public double TotalCalorias { get; set; }
    }
}

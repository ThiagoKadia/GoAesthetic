using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbUsuarios")]
    public class UsuariosViewModel
    {
        [Column("USR_Id")]
        public int Id { get; set; }

        [Column("AUT_Id")]
        public int AutorizacaoId { get; set; }

        [Column("USR_Nome")]
        public string Nome { get; set; }

        [Column("USR_Email")]
        public string Email { get; set; }

        [Column("USR_Senha")]
        public string Senha { get; set; }

        [Column("USR_Idade")]
        public int? Idade { get; set; }

        [Column("USR_Sexo")]
        public int? Sexo { get; set; }

        [Column("USR_Altura")]
        public double? Altura { get; set; }

        [Column("USR_Peso")]
        public double? Peso { get; set; }

        [ForeignKey("AutorizacaoId")]
        public virtual AutorizacaoViewModel Autorizacao { get; set; }

        [NotMapped]
        public string NomeRole { get; set; }
    }
}

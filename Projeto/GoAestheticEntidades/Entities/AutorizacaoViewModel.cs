using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbAutorizacao")]
    public class AutorizacaoViewModel
    {
        [Column("AUT_Id")]
        public int Id { get; set; }

        [Column("AUT_Usuario")]
        public string Usuario { get; set; }

        [Column("AUT_Senha")]
        public string Senha { get; set; }

        [Column("AUT_Role")]
        public string Role { get; set; }
    }
}
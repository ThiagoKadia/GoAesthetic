using System.ComponentModel.DataAnnotations.Schema;

namespace GoAestheticEntidades.Entities
{
    [Table("tbDicionario")]
    public class DicionarioViewModel
    {
        [Column("DIC_Id")]
        public int Id { get; set; }

        [Column("DIC_Chave")]
        public string Chave { get; set; }

        [Column("DIC_Valor")]
        public string Valor { get; set; }
    }
}
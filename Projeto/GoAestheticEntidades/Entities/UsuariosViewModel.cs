using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticEntidades.Entities
{
    [Table("tbUsuarios")]
    public class UsuariosViewModel
    {
        [Column("USR_Id")]
        public int Id { get; set; }

        [Column("RLE_Id")]
        public int RoleId { get; set; }

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

        [ForeignKey("RoleId")]
        public virtual RolesViewModel Role { get; set; }

        [NotMapped]
        public string NomeRole { get; set; }

    }
}

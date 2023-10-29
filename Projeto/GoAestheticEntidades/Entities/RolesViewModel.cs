using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticEntidades.Entities
{
    [Table("tbRoles")]
    public class RolesViewModel
    {
        [Column("RLE_Id")]
        public int Id { get; set; }

        [Column("RLE_Nome")]
        public string Nome { get; set; }
    }
}

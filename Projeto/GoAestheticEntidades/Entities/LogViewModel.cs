using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticEntidades.Entities
{
    [Table("TbLog")]
    public class LogViewModel
    {
        [Column("LOG_Id")]
        public int Id { get; set; }

        [Column("LOG_Erro")]
        public string? Erro { get; set; }

        [Column("LOG_StackTrace")]
        public string? StackTrace { get; set; }

        [Column("LOG_Data")]
        public DateTime Data { get; set; }
    }
}

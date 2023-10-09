using GoAestheticEntidades.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticEntidades
{
    public class GoAestheticDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DUNOTEBOOK\\SQLEDUARDO;Database=GoAestethic;User Id=sa;Password=1camisa*;TrustServerCertificate=True;");
        }

        public DbSet<AlimentosViewModel> AlimentosViewModel { get; set; }
        public DbSet<GrupoAlimentoViewModel> GrupoAlimentoViewModel { get; set; }
        public DbSet<InformacoesAlimentosViewModel> InformacoesAlimentosViewModel { get; set; }
        public DbSet<MarcosEvolucaoViewModel> MarcosEvolucaoViewModel { get; set; }
        public DbSet<RegistroRefeicoesViewModel> RegistroRefeicoesViewModel { get; set; }
        public DbSet<UsuariosViewModel> UsuariosViewModel { get; set; }
    }
}

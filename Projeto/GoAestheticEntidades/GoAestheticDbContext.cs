using GoAestheticEntidades.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoAestheticEntidades
{
    public class GoAestheticDbContext : DbContext
    {
        public GoAestheticDbContext(DbContextOptions<GoAestheticDbContext> options) : base(options)
        {

        }

        public DbSet<AlimentosViewModel> AlimentosViewModel { get; set; }
        public DbSet<GrupoAlimentoViewModel> GrupoAlimentoViewModel { get; set; }
        public DbSet<InformacoesAlimentosViewModel> InformacoesAlimentosViewModel { get; set; }
        public DbSet<MarcosEvolucaoViewModel> MarcosEvolucaoViewModel { get; set; }
        public DbSet<RegistroRefeicoesViewModel> RegistroRefeicoesViewModel { get; set; }
        public DbSet<UsuariosViewModel> UsuariosViewModel { get; set; }
        public DbSet<AutorizacaoViewModel> RolesViewModel { get; set; }
        public DbSet<DicionarioViewModel> DicionarioViewModel { get; set; }
    }
}
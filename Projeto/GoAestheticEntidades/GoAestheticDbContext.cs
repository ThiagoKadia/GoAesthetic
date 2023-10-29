using GoAestheticEntidades.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticEntidades
{
    public class GoAestheticDbContext : IdentityDbContext<IdentityUser>
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
        public DbSet<RolesViewModel> RolesViewModel { get; set; }
    }
}

using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Implementacao.ImplementacaoBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticNegocio.Implementacao
{
    public class LoginNegocio : BaseNegocio
    {
        public LoginNegocio(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task<UsuariosViewModel?> VerificaLoginCorreto(string email, string senha)
        {
            return  await Contexto.UsuariosViewModel.Where(x => x.Email == email && x.Senha == senha)
                                                                .Select(u => new UsuariosViewModel()
                                                                {
                                                                    Nome = u.Nome,
                                                                    Senha = u.Senha,
                                                                    NomeRole = u.Autorizacao.Role
                                                                })
                                                                .AsNoTracking()
                                                                .FirstOrDefaultAsync();
        }
    }
}

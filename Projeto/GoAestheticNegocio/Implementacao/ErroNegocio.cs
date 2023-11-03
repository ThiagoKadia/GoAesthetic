using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Implementacao.ImplementacaoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticNegocio.Implementacao
{
    public class ErroNegocio : BaseNegocio
    {
        public ErroNegocio(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task EscreveErroBanco(Exception ex)
        {
            try
            {
                LogViewModel log = new LogViewModel()
                {
                    Erro = ex.Message,
                    StackTrace = ex.StackTrace,
                    Data = DateTime.Now
                };

                Contexto.LogViewModel.Add(log);
                await Contexto.SaveChangesAsync();
            }
            catch
            {
                //Não logou no banco, já era
            }
        }
    }
}

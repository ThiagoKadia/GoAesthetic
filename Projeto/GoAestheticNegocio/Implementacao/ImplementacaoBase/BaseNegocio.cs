using GoAestheticEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticNegocio.Implementacao.ImplementacaoBase
{
    public class BaseNegocio
    {
        protected GoAestheticDbContext Contexto;
        public BaseNegocio(GoAestheticDbContext context)
        {
            Contexto = context;
        }
    }
}

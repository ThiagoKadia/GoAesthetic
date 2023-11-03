using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticNegocio.Helpers
{
    public static class GenericoHelper
    {
        public static double DivideValorPorCem(double? valor)
        {
            if (valor.HasValue && valor.Value > 0)
                return valor.Value / 100;
            else
                return 0;
        }
    }
}

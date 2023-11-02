using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticNegocio.Helpers
{
    public static class CriptografiaHelper
    {
        public static string CriaHashSenha(string senha)
        {
            byte[] salt = Encoding.ASCII.GetBytes("CriptografiaGoAesthetic");

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                   password: senha,
                                                   salt: salt,
                                                   prf: KeyDerivationPrf.HMACSHA256,
                                                   iterationCount: 100000,
                                                   numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}

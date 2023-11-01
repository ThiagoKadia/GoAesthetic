using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticNegocio.Helpers
{
    public static class EnvironmentHelper
    {
        public static async Task<string> BuscaStringConexaoDb()
        {
            string conexao = string.Empty;
            try
            {
                SecretClient secretclient;
                switch (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                {
                    case "Development":
                        {
                            conexao = Environment.GetEnvironmentVariable("DbConnectionString") ?? "";
                        }
                        break;
                    case "Production":
                        {
                            secretclient = new SecretClient(new Uri("https://goaesthetic.vault.azure.net"), new DefaultAzureCredential());
                            var secret = await secretclient.GetSecretAsync("stringConexaoProd");
                            conexao = secret.Value.Value;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                conexao = String.Empty;
            }

            return conexao;
            
        }

    }
}

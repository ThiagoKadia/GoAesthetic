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

            SecretClient secretclient = new SecretClient(new Uri("https://goaesthetic.vault.azure.net"), new DefaultAzureCredential());
            switch (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
            {
                case "Development":
                    {
                        conexao = Environment.GetEnvironmentVariable("DbConnectionString") ?? "";
                    }
                    break;
                case "Homolog":
                    {
                        var secret = await secretclient.GetSecretAsync("stringConexaoHMG");
                        conexao = secret.Value.Value;
                    }
                    break;
                case "Production":
                    {                     
                        var secret = await secretclient.GetSecretAsync("stringConexaoProd");
                        conexao = secret.Value.Value;
                    }
                    break;
            }

            return conexao;
        }

        public static async Task<string> BuscaStringConexaoStorage()
        {
            SecretClient secretclient;
            secretclient = new SecretClient(new Uri("https://goaesthetic.vault.azure.net"), new DefaultAzureCredential());
            KeyVaultSecret segredo;
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
               segredo  = await secretclient.GetSecretAsync("stringConexaoStorage");
            else
                segredo = await secretclient.GetSecretAsync("stringConexaoStorageHMG");

            return segredo.Value;
        }

        public static async Task<string> BuscaStringSegredoToken()
        {
            string conexao = string.Empty;

            SecretClient secretclient = new SecretClient(new Uri("https://goaesthetic.vault.azure.net"), new DefaultAzureCredential());
            switch (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
            {
                case "Development":
                    {
                        conexao = Environment.GetEnvironmentVariable("StringSegredoToken") ?? "";
                    }
                    break;
                case "Homolog":
                    {
                        var secret = await secretclient.GetSecretAsync("stringSegredoTokenHMG");
                        conexao = secret.Value.Value;
                    }
                    break;
                case "Production":
                    {
                        var secret = await secretclient.GetSecretAsync("stringSegredoTokenProd");
                        conexao = secret.Value.Value;
                    }
                    break;
            }

            return conexao;
        }

    }
}

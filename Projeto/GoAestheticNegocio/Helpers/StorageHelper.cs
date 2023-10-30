using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using GoAestheticNegocio.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticNegocio.Helpers
{
    public class StorageHelper
    {       
        BlobContainerClient conexaoBlobConteiner;

        public StorageHelper()
        {
            BlobServiceClient conexaoBlob = new BlobServiceClient(
                            new Uri(Conexoes.Storage),
                            new DefaultAzureCredential());

            conexaoBlobConteiner = conexaoBlob.GetBlobContainerClient(Conexoes.ConteinerPadrao);
        }

        /// <summary>
        /// Devolve uma string vazia caso sucesso, ou o erro
        /// </summary>
        /// <param name="arquivo"></param>
        /// <param name="nomeArquivo"></param>
        /// <returns></returns>
        public async Task<string> SalvarImagem(MemoryStream arquivo, string nomeArquivo)
        {
            string erro = string.Empty;
            try
            {
                var blockBlob = conexaoBlobConteiner.GetBlockBlobClient(nomeArquivo);
                await conexaoBlobConteiner.CreateIfNotExistsAsync();
                await blockBlob.UploadAsync(arquivo);
            }
            catch (Exception ex)
            {
                erro = ex.ToString();
            }
            return erro;
        }

        /// <summary>
        /// Devolve uma string vazia caso sucesso, ou o erro
        /// </summary>
        /// <param name="nomeArquivo"></param>
        /// <returns></returns>
        public async Task<string> DeletarImagem(string nomeArquivo)
        {
            string erro = string.Empty;
            try
            {
                var blockBlob = conexaoBlobConteiner.GetBlockBlobClient(nomeArquivo);
                await blockBlob.DeleteAsync();
            }
            catch (Exception ex)
            {
                erro = ex.ToString();
            }
            return erro;
        }

        public async Task<MemoryStream> DownloadImagem(string nomeArquivo)
        {
            MemoryStream imagem = new MemoryStream();
            var blockBlob = conexaoBlobConteiner.GetBlockBlobClient(nomeArquivo);
            await blockBlob.DownloadToAsync(imagem);
            return imagem;
        }
    }
   
}

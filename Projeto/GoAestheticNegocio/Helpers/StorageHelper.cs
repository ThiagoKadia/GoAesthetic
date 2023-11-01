using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
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
        BlobContainerClient ConexaoBlobConteiner;

        public StorageHelper()
        {
            BlobServiceClient conexaoBlob = new BlobServiceClient(EnvironmentHelper.BuscaStringConexaoStorage().Result);
            ConexaoBlobConteiner = conexaoBlob.GetBlobContainerClient(Conexoes.ConteinerPadrao);
        }

        public async Task SalvarImagem(MemoryStream arquivo, string nomeArquivo)
        {
            var blockBlob = ConexaoBlobConteiner.GetBlockBlobClient(nomeArquivo);
            await ConexaoBlobConteiner.CreateIfNotExistsAsync();
            await blockBlob.UploadAsync(arquivo);
        }

        public async Task DeletarImagem(string nomeArquivo)
        {
            var blockBlob = ConexaoBlobConteiner.GetBlockBlobClient(nomeArquivo);
            await blockBlob.DeleteAsync();
        }

        public async Task<MemoryStream> DownloadImagem(string nomeArquivo)
        {
            MemoryStream imagem = new MemoryStream();
            var blockBlob = ConexaoBlobConteiner.GetBlockBlobClient(nomeArquivo);
            await blockBlob.DownloadToAsync(imagem);
            return imagem;
        }


        public Uri DownloadImageURI(string nomeArquivo)
        {
            BlobClient blobClient = ConexaoBlobConteiner.GetBlobClient(nomeArquivo);

            BlobSasBuilder sasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = ConexaoBlobConteiner.Name,
                BlobName = blobClient.Name,
                Resource = "b"
            };

            sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddDays(1);
            sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);

            return blobClient.GenerateSasUri(sasBuilder);
        }
    }

}

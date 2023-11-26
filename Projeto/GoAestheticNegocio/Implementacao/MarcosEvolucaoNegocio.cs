using GoAestheticComuns.Classes;
using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAestheticNegocio.Helpers;
using GoAestheticNegocio.Implementacao.ImplementacaoBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAestheticNegocio.Implementacao
{
    public class MarcosEvolucaoNegocio : BaseNegocio
    {
        public MarcosEvolucaoNegocio(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task<List<MarcosEvolucaoViewModel>> BuscarMarcosComFotos(int idUsuario)
        {
            var listaMarcosEvolucao = await Contexto.MarcosEvolucaoViewModel.Where(m => m.UsuarioId == idUsuario && m.NomeArquivoFoto != null)
                                                                            .OrderByDescending(m => m.DataInclusao)
                                                                            .AsNoTracking()
                                                                            .ToListAsync();

            if (listaMarcosEvolucao.Count == 0)
                return listaMarcosEvolucao;


            var storageHelper = new StorageHelper();
            foreach (var marco in listaMarcosEvolucao)
            {
                marco.UrlArquivoStorage = storageHelper.DownloadImageURI(marco.NomeArquivoFoto);
            }

            return listaMarcosEvolucao;
        }

        public async Task CadastraMarcoEvolucao(MarcosEvolucaoViewModel marcosEvolucao, int idUsuario)
        {

            int qtdMarcoEvolucaoUsuario = (await Contexto.MarcosEvolucaoViewModel.CountAsync()) + 1;           

            if (marcosEvolucao.Arquivo != null)
            {
                string nomeArquivo = "MarcoEvolucao" + qtdMarcoEvolucaoUsuario.ToString() + Path.GetExtension(marcosEvolucao.Arquivo.FileName);
                var storageHelper = new StorageHelper();

                using (MemoryStream ms = new MemoryStream())
                {
                    await marcosEvolucao.Arquivo.CopyToAsync(ms);
                    ms.Position = 0;

                    await storageHelper.SalvarImagem(ms, nomeArquivo);
                }

                marcosEvolucao.NomeArquivoFoto = nomeArquivo;
            }

            marcosEvolucao.DataInclusao = DateTime.Now;
            marcosEvolucao.UsuarioId = idUsuario;

            Contexto.MarcosEvolucaoViewModel.Add(marcosEvolucao);
            await Contexto.SaveChangesAsync();

        }


        public async Task<List<RelatorioMarcosEvolucao>> BuscaRelatorioMensal(int idUsuario)
        {
            var relatorio = new List<RelatorioMarcosEvolucao>();

            string[] meses = new string[] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                                            "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"};

            for (int i = 0; i < meses.Length; i++)
            {
                var marcosDoMes = await Contexto.MarcosEvolucaoViewModel.Where(r => r.UsuarioId == idUsuario &&
                                                                                    r.DataInclusao.Month == i + 1)
                                                                        .Select(r => new { r.Altura, r.Peso })
                                                                        .ToListAsync();

                if (marcosDoMes.Count != 0)
                {
                    var rel = new RelatorioMarcosEvolucao()
                    {
                        Referencia = meses[i],
                        Altura = marcosDoMes.Average(r => r.Altura),
                        Peso = marcosDoMes.Average(r => r.Peso)
                    };
                    rel.Referencia = meses[i];
                    relatorio.Add(rel);
                }
            }
            return relatorio;
        }
    }
}

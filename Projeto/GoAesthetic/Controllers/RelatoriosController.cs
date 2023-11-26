using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Respostas;
using GoAestheticComuns.Classes;
using GoAestheticComuns.Enums;
using GoAestheticEntidades;
using GoAestheticNegocio.Implementacao;
using Microsoft.AspNetCore.Mvc;

namespace GoAesthetic.Controllers
{
    public class RelatoriosController : BaseController
    {
        public RelatoriosController(GoAestheticDbContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            return View("Relatorio");
        }


        [HttpPost("/Relatorios/MontaRelatorio")]
        public async Task<IActionResult> MontaRelatorio(TipoGraficoEnum tipoGrafico)
        {           
            var resposta = new RespostaGeraGrafico();

            try
            {
                switch (tipoGrafico)
                {
                    case TipoGraficoEnum.AlimentacaoMensal:
                        {
                            AlimentosNegocio negocio = new AlimentosNegocio(Contexto);
                            var dadosRelatorio = await negocio.BuscaRelatorioMensal(BuscaIdUsuarioLogado());
                            resposta = MontaRelatorioAlimento(dadosRelatorio);
                            resposta.Sucesso = true;
                            break;
                        }
                    case TipoGraficoEnum.AlimentacaoSemanal:
                        {
                            AlimentosNegocio negocio = new AlimentosNegocio(Contexto);
                            var dadosRelatorio = await negocio.BuscaRelatorioSemanal(BuscaIdUsuarioLogado());
                            resposta = MontaRelatorioAlimento(dadosRelatorio);
                            resposta.Sucesso = true;
                            break;
                        }
                    case TipoGraficoEnum.EvolucaoMensal:
                        {
                            MarcosEvolucaoNegocio negocio = new MarcosEvolucaoNegocio(Contexto);
                            var dadosRelatorio = await negocio.BuscaRelatorioMensal(BuscaIdUsuarioLogado());
                            resposta = MontaRelatorioMarcosEvolucao(dadosRelatorio);
                            resposta.Sucesso = true;
                            break;
                        }
                    default:
                        {
                            resposta.Sucesso = false;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                resposta.Erro = true;
                resposta.Mensagem = ex.Message;
                await ErroNegocio.EscreveErroBanco(ex);
            }           

            return Json(resposta);
        }

        private RespostaGeraGrafico MontaRelatorioAlimento (List<RelatorioAlimentos> dados)
        {
            RespostaGeraGrafico grafico = new RespostaGeraGrafico();

            grafico.Labels = new List<string>();
            grafico.Datasets = new List<DataSetGrafico>();

            grafico.Datasets.Add(new DataSetGrafico()
            {
                Label = "Quantidade (g) ",
                Data = new List<double>(),
                BackGroundColor = "rgba(255, 255, 255, 0)",
                BorderColor = "rgba(66, 87, 245, 1)",
                BorderWidth = 2
            });
            grafico.Datasets.Add(new DataSetGrafico()
            {
                Label = "Calorias (Kcal)",
                Data = new List<double>(),
                BackGroundColor = "rgba(255, 255, 255, 0)",
                BorderColor = "rgba(163, 105, 18, 1)",
                BorderWidth = 2
            });
            grafico.Datasets.Add(new DataSetGrafico()
            {
                Label = "Proteinas (g) ",
                Data = new List<double>(),
                BackGroundColor = "rgba(255, 255, 255, 0)",
                BorderColor = "rgba(18, 163, 23, 1)",
                BorderWidth = 2
            });
            grafico.Datasets.Add(new DataSetGrafico()
            {
                Label = "Carboidratos (g)",
                Data = new List<double>(),
                BackGroundColor = "rgba(255, 255, 255, 0)",
                BorderColor = "rgba(94, 90, 16, 1)",
                BorderWidth = 2
            });
            grafico.Datasets.Add(new DataSetGrafico()
            {
                Label = "Gorduras (g)",
                Data = new List<double>(),
                BackGroundColor = "rgba(255, 255, 255, 0)",
                BorderColor = "rgba(181, 174, 180, 1)",
                BorderWidth = 2
            });

            foreach (var referencia in dados)
            {
                grafico.Labels.Add(referencia.Referencia);
                grafico.Datasets[0].Data.Add(referencia.Quantidade);
                grafico.Datasets[1].Data.Add(referencia.Calorias);
                grafico.Datasets[2].Data.Add(referencia.Proteinas);
                grafico.Datasets[3].Data.Add(referencia.Carboidratos);
                grafico.Datasets[4].Data.Add(referencia.Gorduras);
            }

            return grafico;
        }


        private RespostaGeraGrafico MontaRelatorioMarcosEvolucao(List<RelatorioMarcosEvolucao> dados)
        {
            RespostaGeraGrafico grafico = new RespostaGeraGrafico();

            grafico.Labels = new List<string>();
            grafico.Datasets = new List<DataSetGrafico>();

            grafico.Datasets.Add(new DataSetGrafico()
            {
                Label = "Altura (cm) ",
                Data = new List<double>(),
                BackGroundColor = "rgba(255, 255, 255, 0)",
                BorderColor = "rgba(66, 87, 245, 1)",
                BorderWidth = 2
            });
            grafico.Datasets.Add(new DataSetGrafico()
            {
                Label = "Peso (Kg)",
                Data = new List<double>(),
                BackGroundColor = "rgba(255, 255, 255, 0)",
                BorderColor = "rgba(163, 105, 18, 1)",
                BorderWidth = 2
            });
            

            foreach (var referencia in dados)
            {
                grafico.Labels.Add(referencia.Referencia);
                grafico.Datasets[0].Data.Add(referencia.Altura);
                grafico.Datasets[1].Data.Add(referencia.Peso);
            }

            return grafico;
        }
    }
}

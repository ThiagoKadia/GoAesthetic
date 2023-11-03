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
    public class AlimentosNegocio : BaseNegocio
    {
        public AlimentosNegocio(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task<InformacoesAlimentosViewModel> BuscaInformacaoAlimento(int id, double quantidadeGramas)
        {
            
            var alimento = await Contexto.InformacoesAlimentosViewModel.Where(a => a.Id == id).FirstAsync();

            alimento.Quantidade = quantidadeGramas;

            CalculaValoresPorGrama(ref alimento);

            MultiplicaValorPelaQuantidade(ref alimento);
            
            return alimento;
        }

        public void CalculaValoresPorGrama(ref InformacoesAlimentosViewModel informacoes)
        {
            informacoes.Energia = GenericoHelper.DivideValorPorCem(informacoes.Energia);
            informacoes.Proteina = GenericoHelper.DivideValorPorCem(informacoes.Proteina);
            informacoes.Lipideos = GenericoHelper.DivideValorPorCem(informacoes.Lipideos);
            informacoes.Colasterol = GenericoHelper.DivideValorPorCem(informacoes.Colasterol);
            informacoes.Carboidratos = GenericoHelper.DivideValorPorCem(informacoes.Carboidratos);
            informacoes.FibraAlimentar = GenericoHelper.DivideValorPorCem(informacoes.FibraAlimentar);
            informacoes.Ferro = GenericoHelper.DivideValorPorCem(informacoes.Ferro);
            informacoes.VitaminaC = GenericoHelper.DivideValorPorCem(informacoes.VitaminaC);

        }

        public void MultiplicaValorPelaQuantidade(ref InformacoesAlimentosViewModel informacoes)
        {
            informacoes.Energia *= informacoes.Quantidade;
            informacoes.Proteina *= informacoes.Quantidade;
            informacoes.Lipideos *= informacoes.Quantidade;
            informacoes.Colasterol *= informacoes.Quantidade;
            informacoes.Carboidratos *= informacoes.Quantidade;
            informacoes.FibraAlimentar *= informacoes.Quantidade;
            informacoes.Ferro *= informacoes.Quantidade;
            informacoes.VitaminaC *= informacoes.Quantidade;
        }

        public async Task CadastroRefeicao(List<AlimentosViewModel> listaAlimentosAdicionados, string nomeRefeicao, int idUsuarioLogado)
        {
            using var transaction = Contexto.Database.BeginTransaction();
            {
                var refeicao = new RegistroRefeicoesViewModel()
                {
                    Nome = nomeRefeicao,
                    DataInclusao =  DateTime.Now,
                    UsuarioId = idUsuarioLogado
                };

                Contexto.RegistroRefeicoesViewModel.Add(refeicao);
                await Contexto.SaveChangesAsync();

                listaAlimentosAdicionados.ForEach(a => a.RegistroRefeicaoId = refeicao.Id);

                await Contexto.AlimentosViewModel.AddRangeAsync(listaAlimentosAdicionados);
                await Contexto.SaveChangesAsync();

                transaction.Commit();
            }
        }
    }
}

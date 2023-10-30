using GoAestheticEntidades;
using GoAestheticEntidades.Entities;

namespace GoAestheticApi.Repositories
{
    public class BalancaRepository
    {
        private readonly GoAestheticDbContext _dbContext;

        public BalancaRepository(GoAestheticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask SalvaPeso(MarcosEvolucaoViewModel dadosBalanca) 
        {
            await _dbContext.MarcosEvolucaoViewModel.AddAsync(dadosBalanca);
            _dbContext.SaveChanges();
        }
    }
}

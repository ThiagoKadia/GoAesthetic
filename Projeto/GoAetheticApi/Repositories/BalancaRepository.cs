using GoAestheticEntidades;

namespace GoAestheticApi.Repositories
{
    public class BalancaRepository
    {
        private readonly GoAestheticDbContext _dbContext;

        public BalancaRepository(GoAestheticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask SalvaPeso() 
        {

        }
    }
}

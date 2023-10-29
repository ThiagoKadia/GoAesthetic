using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoAestheticApi.Repositories
{
    public class MarcoEvolucaoRepository
    {
        private readonly GoAestheticDbContext _dbContext;

        public MarcoEvolucaoRepository(GoAestheticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<MarcosEvolucaoViewModel> SelectUltimoMarco(string user) 
        {
            return await _dbContext.MarcosEvolucaoViewModel.FirstOrDefaultAsync(x => x.Usuario.Equals(user));
        }
    }
}

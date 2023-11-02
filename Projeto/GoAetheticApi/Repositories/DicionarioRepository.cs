using GoAestheticEntidades;
using Microsoft.EntityFrameworkCore;

namespace GoAestheticApi.Repositories
{
    public class DicionarioRepository
    {
        private readonly GoAestheticDbContext _dbContext;
        public DicionarioRepository(GoAestheticDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async ValueTask<string> GetSignificado(string chave) 
        {
            return (await _dbContext.DicionarioViewModel.FirstOrDefaultAsync(x => x.Chave.Equals(chave))).Valor;
        }
    }
}

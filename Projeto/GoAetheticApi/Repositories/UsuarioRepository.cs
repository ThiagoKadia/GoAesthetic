using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoAestheticApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly GoAestheticDbContext _dbContext;

        public UsuarioRepository(GoAestheticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<int> GetIdPorNomeDeUsuario(string user)
        {
            return (await _dbContext.UsuariosViewModel.FirstOrDefaultAsync(x => x.Nome.Equals(user))).Id;
        }
    }
}
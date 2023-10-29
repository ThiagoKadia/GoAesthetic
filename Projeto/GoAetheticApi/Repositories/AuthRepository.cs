using GoAestheticEntidades;
using GoAestheticEntidades.Entities;
using GoAetheticApi.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace GoAestheticApi.Repositories
{
    public class AuthRepository
    {
        private readonly GoAestheticDbContext _dbContext;

        public AuthRepository(GoAestheticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<AutorizacaoViewModel> SelectUser(AuthRequest user) 
        {
           return await _dbContext.AutorizacaoViewModel.FirstOrDefaultAsync(x => x.Usuario.ToLower().Equals(user.Usuario) &&
                                                                        x.Senha.ToLower().Equals(user.Senha));
        }   
    }
}
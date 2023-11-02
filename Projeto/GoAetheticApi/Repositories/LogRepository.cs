using GoAestheticEntidades;
using GoAestheticEntidades.Entities;

namespace GoAestheticApi.Repositories
{
    public class LogRepository
    {
        private readonly GoAestheticDbContext _dbContext;

        public LogRepository(GoAestheticDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask InsereLog(LogViewModel log) 
        {
            await _dbContext.LogViewModel.AddAsync(log);
            _dbContext.SaveChanges();
        }
    }
}

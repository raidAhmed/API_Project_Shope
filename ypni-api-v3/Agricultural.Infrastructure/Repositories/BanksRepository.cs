using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class BanksRepository : GenericRepository<Banks>,IBanksRepository
    {
        public BanksRepository(ApplicationDbContext context) : base(context)
        {
        }


        
        
    }
}

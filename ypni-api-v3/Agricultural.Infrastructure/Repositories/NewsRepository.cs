using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class NewsRepository : GenericRepository<News>,INewsRepository
    {
        public NewsRepository(ApplicationDbContext context) : base(context)
        {
        }

  

      
    }
}

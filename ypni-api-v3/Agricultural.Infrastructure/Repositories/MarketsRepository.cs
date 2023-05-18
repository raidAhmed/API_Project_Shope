using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Markets;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class MarketsRepository : GenericRepository<Markets>,IMarketsRepository
    {
        public MarketsRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public async Task<IEnumerable<MarketsDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Markets>().Select(x => new MarketsDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}

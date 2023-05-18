using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Unit;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class UnitRepository : GenericRepository<Unit>,IUnitRepository
    {
        public UnitRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public async Task<IEnumerable<UnitDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Unit>().Select(x => new UnitDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}

using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Directorate;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class DirectorateRepository : GenericRepository<Directorate>,IDirectorateRepository
    {
        public DirectorateRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public async Task<IEnumerable<DirectorateDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Directorate>().Select(x => new DirectorateDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}

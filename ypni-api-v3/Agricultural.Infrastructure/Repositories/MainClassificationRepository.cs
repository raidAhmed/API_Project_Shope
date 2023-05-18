using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.MainClassification;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class MainClassificationRepository : GenericRepository<MainClassification>,IMainClassificationRepository
    {
        public MainClassificationRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public async Task<IEnumerable<MainClassificationDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<MainClassification>().Select(x => new MainClassificationDDlLViewModels
            {
                Id = x.Id,
                MainClassificationName = x.MainClassificationName
            }));
        }   

    }
}

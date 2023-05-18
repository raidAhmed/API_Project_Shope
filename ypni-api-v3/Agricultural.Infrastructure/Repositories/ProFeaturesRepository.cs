using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ProFeatures;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ProFeaturesRepository : GenericRepository<ProFeatures>, IProFeaturesRepository
    {
        public ProFeaturesRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<ProFeaturesDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

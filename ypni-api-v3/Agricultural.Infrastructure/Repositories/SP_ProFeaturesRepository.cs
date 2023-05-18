using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.SP_ProFeatures;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class SP_ProFeaturesRepository : GenericRepository<SP_ProFeatures>,ISP_ProFeaturesRepository
    {
        public SP_ProFeaturesRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public Task<IEnumerable<SP_ProFeaturesDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

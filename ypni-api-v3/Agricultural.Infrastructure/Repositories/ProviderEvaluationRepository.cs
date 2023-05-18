using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ProviderEvaluation;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ProviderEvaluationRepository : GenericRepository<ProviderEvaluation>,IProviderEvaluationRepository
    {
        public ProviderEvaluationRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public Task<IEnumerable<ProviderEvaluationDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

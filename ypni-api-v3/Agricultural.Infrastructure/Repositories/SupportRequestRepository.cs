using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.SupportRequest;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class SupportRequestRepository : GenericRepository<SupportRequest>,ISupportRequestRepository
    {
        public SupportRequestRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public Task<IEnumerable<SupportRequestDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

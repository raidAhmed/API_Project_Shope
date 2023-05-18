using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.SP_MainClassification;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class SP_MainClassificationRepository : GenericRepository<SP_MainClassification>,ISP_MainClassificationRepository
    {
        public SP_MainClassificationRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public Task<IEnumerable<SP_MainClassificationDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

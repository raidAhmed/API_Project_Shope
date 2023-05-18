using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.SP_AdditionalSections;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class SP_AdditionalSectionsRepository : GenericRepository<SP_AdditionalSections>,ISP_AdditionalSectionsRepository
    {
        public SP_AdditionalSectionsRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public Task<IEnumerable<SP_AdditionalSectionsDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

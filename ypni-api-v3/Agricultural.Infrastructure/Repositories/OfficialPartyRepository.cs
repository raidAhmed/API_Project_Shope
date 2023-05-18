using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.OfficialParty;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class OfficialPartyRepository : GenericRepository<OfficialParty>,IOfficialPartyRepository
    {
        public OfficialPartyRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<OfficialPartyDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }

    }
}

using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Offer;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class OfferRepository : GenericRepository<Offer>,IOfferRepository
    {
        public OfferRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<OfferDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

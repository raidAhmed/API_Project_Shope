using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Farmer;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class FarmerRepository : GenericRepository<Farmer>,IFarmerRepository
    {
        public FarmerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<FarmerDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

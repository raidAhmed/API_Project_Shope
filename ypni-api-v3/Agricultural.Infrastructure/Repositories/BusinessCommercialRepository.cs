using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.BusinessCommercial;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class BusinessCommercialRepository : GenericRepository<BusinessCommercial>,IBusinessCommercialRepository
    {
        public BusinessCommercialRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<BusinessCommercialDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<BusinessCommercial>().Select(x => new BusinessCommercialDDlLViewModels
            {
                Id = x.Id,
                BankAccount = x.BankAccount
            }));
        }
    }
}

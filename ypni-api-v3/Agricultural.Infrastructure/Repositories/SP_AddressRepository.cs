using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.SP_Address;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class SP_AddressRepository : GenericRepository<SP_Address>,ISP_AddressRepository
    {
        public SP_AddressRepository(ApplicationDbContext context) : base(context)
        {
        }

  

        public async Task<IEnumerable<SP_AddressDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<SP_Address>().Select(x => new SP_AddressDDlLViewModels
            {
                Id = x.Id,
                Street = x.Street
            }));
        }
    }
}

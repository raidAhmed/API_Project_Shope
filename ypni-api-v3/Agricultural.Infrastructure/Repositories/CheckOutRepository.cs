using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.CheckOut;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class CheckOutRepository : GenericRepository<CheckOut>,ICheckOutRepository
    {
        public CheckOutRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<CheckOutDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<CheckOut>().Select(x => new CheckOutDDlLViewModels
            {
                Id = x.Id,
                
            }));
        }
    }
}

using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Order;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<OrderDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Cart;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class CartRepository : GenericRepository<Cart>,ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<CartDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Cart>().Select(x => new CartDDlLViewModels
            {
                Id = x.Id,
                Sku = x.Sku
            }));
        }
    }
}

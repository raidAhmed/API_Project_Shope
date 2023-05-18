using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.CartDetails;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class CartDetailsRepository : GenericRepository<CartDetails>, ICartDetailsRepository
    {
        public CartDetailsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CartdetailsDDLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Cart>().Select(x => new CartdetailsDDLViewModels
            {
                Id = x.Id,
                Sku = x.Sku
            }));
        }
    }
}

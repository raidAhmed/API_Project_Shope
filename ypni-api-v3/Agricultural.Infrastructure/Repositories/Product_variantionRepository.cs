using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product_variantion;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
namespace Agricultural.Infrastructure.Repositories
{
    public class Product_variantionRepository : GenericRepository<Product_variantion>,IProduct_variantionRepository
    {
        public Product_variantionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product_variantion>> getByProductId(int productId)
        {
            var res = await _context.Set<Product_variantion>().AsNoTracking().Where(p => p.ProductId.Value == productId).ToListAsync();
            return res;
        }
        public async Task<IEnumerable<Product_variantionDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

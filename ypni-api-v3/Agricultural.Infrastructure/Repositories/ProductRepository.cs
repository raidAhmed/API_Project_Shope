using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<ProductDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Product>().Select(x => new ProductDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}

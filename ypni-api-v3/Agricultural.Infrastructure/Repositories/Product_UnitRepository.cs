using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product_Unit;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class Product_UnitRepository : GenericRepository<Product_Unit>,IProduct_UnitRepository
    {
        public Product_UnitRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product_UnitDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

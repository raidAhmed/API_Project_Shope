using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product_Unit_Size;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class Product_Unit_SizeRepository : GenericRepository<Product_Unit_Size>,IProduct_Unit_SizeRepository
    {
        public Product_Unit_SizeRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product_Unit_SizeDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

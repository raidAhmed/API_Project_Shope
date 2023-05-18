using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product_Colors;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class Product_ColorsRepository : GenericRepository<Product_Colors>,IProduct_ColorsRepository
    {
        public Product_ColorsRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product_ColorsDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ProductEvaluaton;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ProductEvaluatonRepository : GenericRepository<ProductEvaluaton>,IProductEvaluatonRepository
    {
        public ProductEvaluatonRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<ProductEvaluatonDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

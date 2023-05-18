using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product_Image;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class Product_ImageRepository : GenericRepository<Product_Image>,IProduct_ImageRepository
    {
        public Product_ImageRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product_ImageDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

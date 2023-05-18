using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product_AdditionalDetails;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class Product_AdditionalDetailsRepository : GenericRepository<Product_AdditionalDetails>,IProduct_AdditionalDetailsRepository
    {
        public Product_AdditionalDetailsRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product_AdditionalDetailsDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Product_AdditionalDetails>().Select(x => new Product_AdditionalDetailsDDlLViewModels
            {
                Id = x.Id,
                Title = x.Title
            }));
        }
    }
}

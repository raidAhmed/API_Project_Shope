using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product_Attribute;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class Product_AttributeRepository : GenericRepository<Product_Attribute>,IProduct_AttributeRepository
    {
        public Product_AttributeRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product_AttributeDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<Product_Attribute>().Select(x => new Product_AttributeDDlLViewModels
            {
                Id = x.Id,
                Name = x.Name
            }));
        }
    }
}

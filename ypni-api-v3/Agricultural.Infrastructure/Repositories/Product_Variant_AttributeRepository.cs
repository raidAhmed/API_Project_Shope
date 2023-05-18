using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.Product_Variant_Attribute;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class Product_Variant_AttributeRepository : GenericRepository<Product_Variant_Attribute>,IProduct_Variant_AttributeRepository
    {
        public Product_Variant_AttributeRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product_Variant_AttributeDDlLViewModels>> GetDDL()
        {
            throw new NotImplementedException();
        }
    }
}

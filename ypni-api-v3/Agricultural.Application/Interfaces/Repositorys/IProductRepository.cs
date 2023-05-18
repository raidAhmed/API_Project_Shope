using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProductRepository: IGenericRepository<Product>
    {
       
        Task<IEnumerable<ProductDDlLViewModels>> GetDDL();
    }
}

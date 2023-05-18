using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_variantion;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProduct_variantionRepository: IGenericRepository<Product_variantion>
    {
   
        Task<IEnumerable<Product_variantionDDlLViewModels>> GetDDL();
        Task<IEnumerable<Product_variantion>> getByProductId(int productId);

    }
}

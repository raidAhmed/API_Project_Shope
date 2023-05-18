using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Unit_Size;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProduct_Unit_SizeRepository: IGenericRepository<Product_Unit_Size>
    {
        
        Task<IEnumerable<Product_Unit_SizeDDlLViewModels>> GetDDL();
    }
}

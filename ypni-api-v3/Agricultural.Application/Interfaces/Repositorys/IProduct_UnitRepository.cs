using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Unit;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProduct_UnitRepository: IGenericRepository<Product_Unit>
    {
        
        Task<IEnumerable<Product_UnitDDlLViewModels>> GetDDL();
    }
}

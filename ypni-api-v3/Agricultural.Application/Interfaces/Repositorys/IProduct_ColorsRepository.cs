using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Colors;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProduct_ColorsRepository: IGenericRepository<Product_Colors>
    {
       
        Task<IEnumerable<Product_ColorsDDlLViewModels>> GetDDL();
    }
}

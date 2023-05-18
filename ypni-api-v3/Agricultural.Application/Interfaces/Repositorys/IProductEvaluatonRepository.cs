using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ProductEvaluaton;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProductEvaluatonRepository: IGenericRepository<ProductEvaluaton>
    {
   
        Task<IEnumerable<ProductEvaluatonDDlLViewModels>> GetDDL();
    }
}

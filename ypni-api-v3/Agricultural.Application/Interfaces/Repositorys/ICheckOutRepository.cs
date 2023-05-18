using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.CheckOut;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ICheckOutRepository: IGenericRepository<CheckOut>
    {
      
        Task<IEnumerable<CheckOutDDlLViewModels>> GetDDL();
    }
}

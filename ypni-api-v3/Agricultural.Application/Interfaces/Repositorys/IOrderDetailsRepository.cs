using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Order;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
    {
       
        Task<IEnumerable<OrderDDlLViewModels>> GetDDL();
    }
}

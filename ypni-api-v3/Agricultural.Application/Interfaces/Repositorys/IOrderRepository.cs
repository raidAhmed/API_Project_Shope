using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Order;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
       
        Task<IEnumerable<OrderDDlLViewModels>> GetDDL();
    }
}

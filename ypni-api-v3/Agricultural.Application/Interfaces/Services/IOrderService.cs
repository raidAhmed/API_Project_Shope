using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Order;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Order;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IResult<OrderQueryDto>> Add(OrderDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OrderQueryDto>>> Find(Expression<Func<OrderQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<OrderQueryDto>>> Find(DtRequest dtRequest, Expression<Func<OrderQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OrderQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<OrderQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<OrderQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OrderDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<OrderQueryDto>> Update(OrderDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(OrderDto entity, CancellationToken cancellationToken = default);
    }
}

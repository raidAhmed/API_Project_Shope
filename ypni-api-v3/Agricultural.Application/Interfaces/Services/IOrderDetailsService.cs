using Agricultural.Application.Common;
using Agricultural.Application.DTOs.OrderDetails;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Order;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IOrderDetailsService
    {
        Task<IResult<OrderDetailsQueryDto>> Add(OrderDetailsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OrderDetailsQueryDto>>> Find(Expression<Func<OrderDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<OrderDetailsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<OrderDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OrderDetailsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<OrderDetailsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<OrderDetailsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OrderDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<OrderDetailsQueryDto>> Update(OrderDetailsDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(OrderDetailsDto entity, CancellationToken cancellationToken = default);
    }
}

using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Cart;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Cart;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ICartService
    {
        Task<IResult<CartQueryDto>> Add(CartDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CartQueryDto>>> Find(Expression<Func<CartQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CartQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CartQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CartQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CartQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<CartQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CartDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<CartQueryDto>> Update(CartDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(CartDto entity, CancellationToken cancellationToken = default);
    }
}

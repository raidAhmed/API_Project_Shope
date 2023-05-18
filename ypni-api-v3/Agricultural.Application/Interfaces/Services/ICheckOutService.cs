using Agricultural.Application.Common;
using Agricultural.Application.DTOs.CheckOut;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.CheckOut;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ICheckOutService
    {
        Task<IResult<CheckOutQueryDto>> Add(CheckOutDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CheckOutQueryDto>>> Find(Expression<Func<CheckOutQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CheckOutQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CheckOutQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CheckOutQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CheckOutQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<CheckOutQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CheckOutDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<CheckOutQueryDto>> Update(CheckOutDto entity, CancellationToken cancellationToken = default);

        Task<IResult> ChangeActive(CheckOutDto entity, CancellationToken cancellationToken = default);
    }
}

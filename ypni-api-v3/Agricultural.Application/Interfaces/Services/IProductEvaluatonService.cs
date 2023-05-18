using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ProductEvaluaton;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ProductEvaluaton;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProductEvaluatonService
    {
        Task<IResult<ProductEvaluatonQueryDto>> Add(ProductEvaluatonDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProductEvaluatonQueryDto>>> Find(Expression<Func<ProductEvaluatonQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ProductEvaluatonQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ProductEvaluatonQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProductEvaluatonQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ProductEvaluatonQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ProductEvaluatonQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProductEvaluatonDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ProductEvaluatonQueryDto>> Update(ProductEvaluatonDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ProductEvaluatonDto entity, CancellationToken cancellationToken = default);
    }
}

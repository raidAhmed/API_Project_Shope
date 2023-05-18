using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Markets;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Markets;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IMarketsService
    {
        Task<IResult<MarketsQueryDto>> Add(MarketsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MarketsQueryDto>>> Find(Expression<Func<MarketsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<MarketsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<MarketsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MarketsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<MarketsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<MarketsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MarketsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<MarketsQueryDto>> Update(MarketsDto entity, CancellationToken cancellationToken = default);

         Task<IResult> ChangeActive(MarketsDto entity,CancellationToken cancellationToken=default);
    }
}

using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Offer;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Offer;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IOfferService
    {
        Task<IResult<OfferQueryDto>> Add(OfferDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OfferQueryDto>>> Find(Expression<Func<OfferQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<OfferQueryDto>>> Find(DtRequest dtRequest, Expression<Func<OfferQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OfferQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<OfferQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<OfferQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OfferDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<OfferQueryDto>> Update(OfferDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(OfferDto entity, CancellationToken cancellationToken = default);
    }
}

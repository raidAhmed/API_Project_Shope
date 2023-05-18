using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ProFeatures;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ProFeatures;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProFeaturesService
    {
        Task<IResult<ProFeaturesQueryDto>> Add(ProFeaturesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProFeaturesQueryDto>>> Find(Expression<Func<ProFeaturesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ProFeaturesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ProFeaturesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProFeaturesQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ProFeaturesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ProFeaturesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProFeaturesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ProFeaturesQueryDto>> Update(ProFeaturesDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ProFeaturesDto entity, CancellationToken cancellationToken = default);
    }
}

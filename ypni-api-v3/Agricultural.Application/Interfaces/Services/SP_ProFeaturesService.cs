using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_ProFeatures;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_ProFeatures;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ISP_ProFeaturesService
    {
        Task<IResult<SP_ProFeaturesQueryDto>> Add(SP_ProFeaturesDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_ProFeaturesQueryDto>>> Find(Expression<Func<SP_ProFeaturesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_ProFeaturesQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_ProFeaturesQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_ProFeaturesQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_ProFeaturesQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<SP_ProFeaturesQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_ProFeaturesDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<SP_ProFeaturesQueryDto>> Update(SP_ProFeaturesDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(SP_ProFeaturesDto entity, CancellationToken cancellationToken = default);
    }
}

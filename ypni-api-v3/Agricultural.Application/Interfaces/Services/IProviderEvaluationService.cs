using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ProviderEvaluation;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ProviderEvaluation;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProviderEvaluationService
    {
        Task<IResult<ProviderEvaluationQueryDto>> Add(ProviderEvaluationDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProviderEvaluationQueryDto>>> Find(Expression<Func<ProviderEvaluationQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ProviderEvaluationQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ProviderEvaluationQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProviderEvaluationQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ProviderEvaluationQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ProviderEvaluationQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProviderEvaluationDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ProviderEvaluationQueryDto>> Update(ProviderEvaluationDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ProviderEvaluationDto entity, CancellationToken cancellationToken = default);
    }
}

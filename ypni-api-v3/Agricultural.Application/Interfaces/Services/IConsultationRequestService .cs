using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ConsultationRequest;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ConsultationRequest;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IConsultationRequestService
    {
        Task<IResult<ConsultationRequestQueryDto>> Add(ConsultationRequestDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ConsultationRequestQueryDto>>> Find(Expression<Func<ConsultationRequestQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ConsultationRequestQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ConsultationRequestQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ConsultationRequestQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ConsultationRequestQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ConsultationRequestQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ConsultationRequestDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ConsultationRequestQueryDto>> Update(ConsultationRequestDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ConsultationRequestDto entity, CancellationToken cancellationToken = default);
    }
}

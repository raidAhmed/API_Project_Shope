using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SupportRequest;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SupportRequest;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ISupportRequestService
    {
        Task<IResult<SupportRequestQueryDto>> Add(SupportRequestDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SupportRequestQueryDto>>> Find(Expression<Func<SupportRequestQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SupportRequestQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SupportRequestQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SupportRequestQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SupportRequestQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<SupportRequestQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SupportRequestDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<SupportRequestQueryDto>> Update(SupportRequestDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(SupportRequestDto entity, CancellationToken cancellationToken = default);
    }
}

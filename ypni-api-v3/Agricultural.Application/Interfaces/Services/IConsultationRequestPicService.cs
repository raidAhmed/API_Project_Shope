using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ConsultationRequestPic;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ConsultationRequestPic;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IConsultationRequestPicService
    {
        Task<IResult<ConsultationRequestPicQueryDto>> Add(ConsultationRequestPicDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ConsultationRequestPicQueryDto>>> Find(Expression<Func<ConsultationRequestPicQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ConsultationRequestPicQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ConsultationRequestPicQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ConsultationRequestPicQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ConsultationRequestPicQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ConsultationRequestPicQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ConsultationRequestPicDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ConsultationRequestPicQueryDto>> Update(ConsultationRequestPicDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ConsultationRequestPicDto entity, CancellationToken cancellationToken = default);
    }
}

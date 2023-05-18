using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_MainClassification;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_MainClassification;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ISP_MainClassificationService
    {
        Task<IResult<SP_MainClassificationQueryDto>> Add(SP_MainClassificationDto entity, CancellationToken cancellationToken = default);
        Task<IResult<List<SP_MainClassificationQueryDto>>> Addlistt(List<SP_MainClassificationDtoApi> entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_MainClassificationQueryDto>>> Find(Expression<Func<SP_MainClassificationQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_MainClassificationQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_MainClassificationQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_MainClassificationQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_MainClassificationQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<SP_MainClassificationQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_MainClassificationDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);
        Task<IResult> Addlist(List<SP_MainClassificationDto> entity ,CancellationToken cancellationToken = default);
       // Task<IResult> GetSpMainclassfication(CancellationToken cancellationToken = default);


        Task<IResult<SP_MainClassificationQueryDto>> Update(SP_MainClassificationDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(SP_MainClassificationDto entity, CancellationToken cancellationToken = default);
    }
}

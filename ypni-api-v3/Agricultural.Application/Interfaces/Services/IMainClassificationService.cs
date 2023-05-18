    using Agricultural.Application.Common;
using Agricultural.Application.DTOs.MainClassification;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.MainClassification;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IMainClassificationService
    {
        Task<IResult<MainClassificationQueryDto>> Add(MainClassificationDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MainClassificationQueryDto>>> Find(Expression<Func<MainClassificationQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<MainClassificationQueryDto>>> Find(DtRequest dtRequest, Expression<Func<MainClassificationQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MainClassificationQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<MainClassificationQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<MainClassificationQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MainClassificationDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<MainClassificationQueryDto>> Update(MainClassificationDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(MainClassificationDto entity, CancellationToken cancellationToken = default);
    }
}

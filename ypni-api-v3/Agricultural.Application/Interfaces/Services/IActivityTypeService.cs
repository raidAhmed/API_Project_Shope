using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ActivityType;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ActivityType;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IActivityTypeService
    {
        Task<IResult<ActivityTypeQueryDto>> Add(ActivityTypeDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ActivityTypeQueryDto>>> Find(Expression<Func<ActivityTypeQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ActivityTypeQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ActivityTypeQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ActivityTypeQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ActivityTypeQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ActivityTypeQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ActivityTypeDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ActivityTypeQueryDto>> Update(ActivityTypeDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ActivityTypeDto entity, CancellationToken cancellationToken = default);
    }
}

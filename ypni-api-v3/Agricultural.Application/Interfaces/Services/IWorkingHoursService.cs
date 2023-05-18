using Agricultural.Application.Common;
using Agricultural.Application.DTOs.WorkingHours;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IWorkingHoursService
    {
        Task<IResult<WorkingHoursQueryDto>> Add(WorkingHoursDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<WorkingHoursQueryDto>>> Find(Expression<Func<WorkingHoursQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<WorkingHoursQueryDto>>> Find(DtRequest dtRequest, Expression<Func<WorkingHoursQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<WorkingHoursQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<WorkingHoursQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<WorkingHoursQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<WorkingHoursQueryDto>> Update(WorkingHoursDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(WorkingHoursDto entity, CancellationToken cancellationToken = default);
    }
}

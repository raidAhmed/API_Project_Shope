using Agricultural.Application.Common;
using Agricultural.Application.DTOs.WorkinPoeriods;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IWorkinPoeriodsService
    {
        Task<IResult<WorkinPoeriodsQueryDto>> Add(WorkinPoeriodsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<WorkinPoeriodsQueryDto>>> Find(Expression<Func<WorkinPoeriodsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<WorkinPoeriodsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<WorkinPoeriodsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<WorkinPoeriodsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<WorkinPoeriodsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<WorkinPoeriodsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<WorkinPoeriodsQueryDto>> Update(WorkinPoeriodsDto entity, CancellationToken cancellationToken = default);
      
    }
}

using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Weekdays;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IWeekdaysService
    {
        Task<IResult<WeekdaysQueryDto>> Add(WeekdaysDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<WeekdaysQueryDto>>> Find(Expression<Func<WeekdaysQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<WeekdaysQueryDto>>> Find(DtRequest dtRequest, Expression<Func<WeekdaysQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<WeekdaysQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<WeekdaysQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<WeekdaysQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<WeekdaysQueryDto>> Update(WeekdaysDto entity, CancellationToken cancellationToken = default);
     
    }
}

using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Unit;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Unit;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IUnitService
    {
        Task<IResult<UnitQueryDto>> Add(UnitDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<UnitQueryDto>>> Find(Expression<Func<UnitQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<UnitQueryDto>>> Find(DtRequest dtRequest, Expression<Func<UnitQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<UnitQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<UnitQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<UnitQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<UnitDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<UnitQueryDto>> Update(UnitDto entity, CancellationToken cancellationToken = default);

         Task<IResult> ChangeActive(UnitDto entity,CancellationToken cancellationToken=default);
    }
}

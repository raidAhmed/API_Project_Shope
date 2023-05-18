using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Color;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Color;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IColorService
    {
        Task<IResult<ColorQueryDto>> Add(ColorDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ColorQueryDto>>> Find(Expression<Func<ColorQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ColorQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ColorQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ColorQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ColorQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ColorQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ColorDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ColorQueryDto>> Update(ColorDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ColorDto entity, CancellationToken cancellationToken = default);
    }
}

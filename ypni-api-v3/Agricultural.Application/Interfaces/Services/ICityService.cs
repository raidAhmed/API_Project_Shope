using Agricultural.Application.Common;
using Agricultural.Application.DTOs.City;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.City;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ICityService
    {
        Task<IResult<CityQueryDto>> Add(CityDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CityQueryDto>>> Find(Expression<Func<CityQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CityQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CityQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CityQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CityQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<CityQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CityDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<CityQueryDto>> Update(CityDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(CityDto entity, CancellationToken cancellationToken = default);
    }
}

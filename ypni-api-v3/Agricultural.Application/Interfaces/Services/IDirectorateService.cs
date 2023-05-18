using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Directorate;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Directorate;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IDirectorateService
    {
        Task<IResult<DirectorateQueryDto>> Add(DirectorateDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<DirectorateQueryDto>>> Find(Expression<Func<DirectorateQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<DirectorateQueryDto>>> Find(DtRequest dtRequest, Expression<Func<DirectorateQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<DirectorateQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<DirectorateQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<DirectorateQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<DirectorateDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<DirectorateQueryDto>> Update(DirectorateDto entity, CancellationToken cancellationToken = default);

         Task<IResult> ChangeActive(DirectorateDto entity,CancellationToken cancellationToken=default);
    }
}

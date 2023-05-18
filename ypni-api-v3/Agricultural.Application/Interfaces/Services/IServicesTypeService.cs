using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ServicesType;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ServicesType;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IServicesTypeService
    {
        Task<IResult<ServicesTypeQueryDto>> Add(ServicesTypeDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ServicesTypeQueryDto>>> Find(Expression<Func<ServicesTypeQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ServicesTypeQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ServicesTypeQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ServicesTypeQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ServicesTypeQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ServicesTypeQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ServicesTypeDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ServicesTypeQueryDto>> Update(ServicesTypeDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ServicesTypeDto entity, CancellationToken cancellationToken = default);
    }
}

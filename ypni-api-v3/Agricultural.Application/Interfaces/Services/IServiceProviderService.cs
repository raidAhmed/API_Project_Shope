using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ServiceProvider;
using Agricultural.Application.DTOs.User;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ServiceProvider;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IServiceProviderService
    {
        Task<IResult<UserUpdateDto>> UpdateUserStatus(string Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ServiceProviderQueryDto>>> FindAll(Expression<Func<ServiceProviderQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<ServiceProviderDto>> Add(ServiceProviderDto entity, CancellationToken cancellationToken = default);
        //   Task<IResult<ServiceProviderDto>> RemoveAfter(ServiceProviderDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ServiceProviderQueryDto>>> Find(Expression<Func<ServiceProviderQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ServiceProviderQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ServiceProviderQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ServiceProviderQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ServiceProviderQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ServiceProviderDto>> GetById(int Id, CancellationToken cancellationToken = default); 
        Task<IResult<ServiceProviderDto>> GetByIdd(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ServiceProviderDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);
        Task<IResult<ServiceProviderQueryDto>> Update(ServiceProviderDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ServiceProviderDto entity, CancellationToken cancellationToken = default);
    }
}

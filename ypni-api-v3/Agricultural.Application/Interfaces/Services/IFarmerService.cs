using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Farmer;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Farmer;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IFarmerService
    {
        Task<IResult<FarmerQueryDto>> Add(FarmerDto entity, CancellationToken cancellationToken = default);
        Task<IResult<FarmerDto>> Find(Expression<Func<FarmerDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<FarmerQueryDto>>> Find(DtRequest dtRequest, Expression<Func<FarmerQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<FarmerQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<FarmerQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<FarmerQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<FarmerDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<FarmerQueryDto>> Update(FarmerDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(FarmerDto entity, CancellationToken cancellationToken = default);
    }
}

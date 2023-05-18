using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Banks;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IBanksService
    {
        Task<IResult<BanksQueryDto>> Add(BanksDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<BanksQueryDto>>> Find(Expression<Func<BanksQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<BanksQueryDto>>> Find(DtRequest dtRequest, Expression<Func<BanksQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<BanksQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<BanksQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<BanksQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);
        Task<IResult<BanksQueryDto>> Update(BanksDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(BanksDto entity, CancellationToken cancellationToken = default);
    }
}

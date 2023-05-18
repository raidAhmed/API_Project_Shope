using Agricultural.Application.Common;
using Agricultural.Application.DTOs.OfficialParty;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.OfficialParty;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IOfficialPartyService
    {
        Task<IResult<OfficialPartyQueryDto>> Add(OfficialPartyDto entity, CancellationToken cancellationToken = default);
        Task<IResult<OfficialPartyDto>> Find(Expression<Func<OfficialPartyDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<OfficialPartyQueryDto>>> Find(DtRequest dtRequest, Expression<Func<OfficialPartyQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OfficialPartyQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<OfficialPartyQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<OfficialPartyQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<OfficialPartyDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<OfficialPartyQueryDto>> Update(OfficialPartyDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(OfficialPartyDto entity, CancellationToken cancellationToken = default);
    }
}

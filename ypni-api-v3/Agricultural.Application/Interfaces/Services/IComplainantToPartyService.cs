using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ComplainantToParty;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ComplainantToParty;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IComplainantToPartyService
    {
        Task<IResult<ComplainantToPartyQueryDto>> Add(ComplainantToPartyDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ComplainantToPartyQueryDto>>> Find(Expression<Func<ComplainantToPartyQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ComplainantToPartyQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ComplainantToPartyQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ComplainantToPartyQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Complminttopartyapi>>> GetAlll(string useridd, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ComplainantToPartyQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ComplainantToPartyQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ComplainantToPartyQueryDto>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ComplainantToPartyQueryDto>> Update(ComplainantToPartyQueryDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ComplainantToPartyDto entity, CancellationToken cancellationToken = default);
    }
}

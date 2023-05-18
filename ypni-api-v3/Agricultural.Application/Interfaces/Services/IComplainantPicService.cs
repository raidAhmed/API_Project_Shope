using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ComplainantPic;
using Agricultural.Application.DTOs.ComplainantToParty;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ComplainantPic;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IComplainantPicService
    {
        Task<IResult<ComplainantPicQueryDto>> Add(ComplainantPicDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ComplainantPicQueryDto>>> Find(Expression<Func<ComplainantPicQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ComplainantPicQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ComplainantPicQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ComplainantPicQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ComplainantPicQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ComplainantPicQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ComplainantPicDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ComplainantPicQueryDto>> Update(ComplainantPicDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ComplainantPicDto entity, CancellationToken cancellationToken = default);
    }
}

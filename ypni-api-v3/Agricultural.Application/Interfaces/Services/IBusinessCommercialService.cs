using Agricultural.Application.Common;
using Agricultural.Application.DTOs.BusinessCommercial;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.BusinessCommercial;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IBusinessCommercialService
    {
        Task<IResult<BusinessCommercialQueryDto>> Add(BusinessCommercialDto entity, CancellationToken cancellationToken = default);
        Task<IResult<BusinessCommercialDto>> Find(Expression<Func<BusinessCommercialDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<BusinessCommercialQueryDto>>> Find(DtRequest dtRequest, Expression<Func<BusinessCommercialQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<BusinessCommercialQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<BusinessCommercialQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<BusinessCommercialQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<BusinessCommercialDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<BusinessCommercialQueryDto>> Update(BusinessCommercialDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(BusinessCommercialDto entity, CancellationToken cancellationToken = default);
    }
}

using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Brand;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Brand;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IBrandService
    {
        Task<IResult<BrandQueryDto>> Add(BrandDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<BrandQueryDto>>> Find(Expression<Func<BrandQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<BrandQueryDto>>> Find(DtRequest dtRequest, Expression<Func<BrandQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<BrandQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<BrandQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<BrandQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<BrandDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<BrandQueryDto>> Update(BrandDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(BrandDto entity, CancellationToken cancellationToken = default);
    }
}

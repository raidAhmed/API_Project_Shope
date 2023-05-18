using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_variantion;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_variantion;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProduct_variantionService
    {
        Task<IResult<IEnumerable<Product_variantionQueryDto>>> getByProductId(int productId, CancellationToken cancellationToken = default);

        Task<IResult<Product_variantionQueryDto>> Add(Product_variantionDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_variantionQueryDto>>> Find(Expression<Func<Product_variantionQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_variantionQueryDto>>> Findd(int productid, CancellationToken cancellationToken = default);
        //   Task<IResult<IEnumerable<Product_variantionDto>>> FindMvc(Expression<Func<Product_variantionDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_variantionQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_variantionQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_variantionQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_variantionQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<Product_variantionQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_variantionDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);

        Task<IResult> Removemvc(Product_variantionDto entity, CancellationToken cancellationToken = default);
        Task<IResult<Product_variantionQueryDto>> Update(Product_variantionDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(Product_variantionDto entity, CancellationToken cancellationToken = default);
    }
}

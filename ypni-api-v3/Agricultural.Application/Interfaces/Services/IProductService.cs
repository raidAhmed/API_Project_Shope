using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProductService
    {
         Task<IResult<IEnumerable<productdtoADDapi>>> GetAllProPagination(Expression<Func<ProductQueryDto, bool>> expression, int skip, int take, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<productdtoADDapi>>> GetAllProById(Expression<Func<ProductQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<ProductQueryDto>> Add(ProductDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProductQueryDto>>> Find(Expression<Func<ProductQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<productdtoADDapi>>> GetAllProApi(CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<productdtoADDapi>>> GetAllByServiceProviderIdAndMainClassificationId(int mainClassificationId, int serviceProviderId, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<productdtoADDapi>>> GetAllByServiceProviderIdAndAdditionalSectionsId(int additionalSectionsId, int serviceProviderId, CancellationToken cancellationToken = default);
        Task<IResult<productdtoADDapi>> AddApi(productdtoADDapi entity, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ProductQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ProductQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProductQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ProductQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ProductQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<ProductQueryDto>> GetByIdMvc(int Id, CancellationToken cancellationToken = default);
        Task<IResult<listgetprodict>> GetAlllistforAdd(CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ProductDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);

        Task<IResult<ProductQueryDto>> Updatemvc(ProductQueryDto entity, CancellationToken cancellationToken = default);
        Task<IResult<ProductQueryDto>> Update(ProductDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ProductDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeStateForProduct(ProductDto entity, CancellationToken cancellationToken = default);
    }
}

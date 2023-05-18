using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Image;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Image;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProduct_ImageService
    {
        Task<IResult<Product_ImageQueryDto>> Add(Product_ImageDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_ImageQueryDto>>> Find(Expression<Func<Product_ImageQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_ImageQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_ImageQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_ImageQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_ImageQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<Product_ImageQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_ImageDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);
        Task<IResult> Removemvc(Product_ImageDto entity, CancellationToken cancellationToken = default);

        Task<IResult<Product_ImageQueryDto>> Update(Product_ImageDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(Product_ImageDto entity, CancellationToken cancellationToken = default);
    }
}

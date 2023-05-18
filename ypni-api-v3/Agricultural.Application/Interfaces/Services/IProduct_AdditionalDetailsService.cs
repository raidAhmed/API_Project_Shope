using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_AdditionalDetails;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_AdditionalDetails;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProduct_AdditionalDetailsService
    {
        Task<IResult<Product_AdditionalDetailsQueryDto>> Add(Product_AdditionalDetailsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_AdditionalDetailsQueryDto>>> Find(Expression<Func<Product_AdditionalDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_AdditionalDetailsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_AdditionalDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_AdditionalDetailsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_AdditionalDetailsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<Product_AdditionalDetailsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_AdditionalDetailsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<Product_AdditionalDetailsQueryDto>> Update(Product_AdditionalDetailsDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(Product_AdditionalDetailsDto entity, CancellationToken cancellationToken = default);
    }
}

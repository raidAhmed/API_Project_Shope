using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Attribute;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Attribute;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProduct_AttributeService
    {
        Task<IResult<Product_AttributeQueryDto>> Add(Product_AttributeDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_AttributeQueryDto>>> Find(Expression<Func<Product_AttributeQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_AttributeQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_AttributeQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_AttributeQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_AttributeQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<Product_AttributeQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_AttributeDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<Product_AttributeQueryDto>> Update(Product_AttributeDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(Product_AttributeDto entity, CancellationToken cancellationToken = default);
    }
}

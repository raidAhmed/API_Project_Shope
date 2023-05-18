using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Variant_Attribute;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Variant_Attribute;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProduct_Variant_AttributeService
    {
        Task<IResult<Product_Variant_AttributeQueryDto>> Add(Product_Variant_AttributeDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_Variant_AttributeQueryDto>>> Find(Expression<Func<Product_Variant_AttributeQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_Variant_AttributeQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_Variant_AttributeQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_Variant_AttributeQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_Variant_AttributeQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<Product_Variant_AttributeQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_Variant_AttributeDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<Product_Variant_AttributeQueryDto>> Update(Product_Variant_AttributeDto entity, CancellationToken cancellationToken = default);

        Task<IResult> ChangeActive(Product_Variant_AttributeDto entity, CancellationToken cancellationToken = default);
    }
}

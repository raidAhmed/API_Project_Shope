using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Colors;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Colors;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProduct_ColorsService
    {
        Task<IResult<Product_ColorsQueryDto>> Add(Product_ColorsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_ColorsQueryDto>>> Find(Expression<Func<Product_ColorsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_ColorsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_ColorsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_ColorsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_ColorsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<Product_ColorsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_ColorsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);
        Task<IResult> Removemvc(Product_ColorsDto entity, CancellationToken cancellationToken = default);


        Task<IResult<Product_ColorsQueryDto>> Update(Product_ColorsDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(Product_ColorsDto entity, CancellationToken cancellationToken = default);
    }
}

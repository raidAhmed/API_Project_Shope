using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product_Unit;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Unit;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IProduct_UnitService
    {
        Task<IResult<Product_UnitQueryDto>> Add(Product_UnitDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_UnitQueryDto>>> Find(Expression<Func<Product_UnitQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_UnitQueryDto>>> Find(DtRequest dtRequest, Expression<Func<Product_UnitQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_UnitQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<Product_UnitQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<Product_UnitQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<Product_UnitDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<Product_UnitQueryDto>> Update(Product_UnitDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(Product_UnitDto entity, CancellationToken cancellationToken = default);
    }
}

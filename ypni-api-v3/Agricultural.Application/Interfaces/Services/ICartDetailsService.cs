using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agricultural.Application.Common;
using Agricultural.Application.DTOs.CartDetails;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.CartDetails;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ICartDetailsService
    {
        Task<IResult<CartDetailsQueryDto>> Add(CartDetailsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CartDetailsQueryDto>>> Find(Expression<Func<CartDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CartDetailsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CartDetailsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CartDetailsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CartDetailsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<CartDetailsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CartdetailsDDLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);
        Task<IResult<CartDetailsDto>> RemoveAndReturn(int Id, CancellationToken cancellationToken = default);


        Task<IResult<CartDetailsQueryDto>> Update(CartDetailsDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(CartDetailsDto entity, CancellationToken cancellationToken = default);
    }
}

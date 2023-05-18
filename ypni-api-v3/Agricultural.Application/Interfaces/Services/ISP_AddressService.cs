using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SP_Address;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_Address;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ISP_AddressService
    {
        Task<IResult<SP_AddressQueryDto>> Add(SP_AddressDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AddressDto>>> Find(Expression<Func<SP_AddressDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_AddressQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_AddressQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AddressQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_AddressQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<SP_AddressDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AddressQueryDto>>> FindByServicePro(Expression<Func<SP_AddressDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AddressDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<SP_AddressQueryDto>> Update(SP_AddressDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(SP_AddressDto entity, CancellationToken cancellationToken = default);
    }
}

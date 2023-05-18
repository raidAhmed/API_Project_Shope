using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ActivityType;
using Agricultural.Application.DTOs.Currency;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Interfaces.Services
{
    public interface  ICurrencyService
    {
        Task<IResult<CurrencyQueryDto>> Add(CurrencyDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CurrencyQueryDto>>> Find(Expression<Func<CurrencyQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CurrencyQueryDto>>> Find(DtRequest dtRequest, Expression<Func<CurrencyQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CurrencyQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        List<CurrencyQueryDto> GetAllmvc(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<CurrencyQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<CurrencyQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<CurrencyDto>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);
        Task<IResult<CurrencyQueryDto>> Update(CurrencyDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(CurrencyDto entity, CancellationToken cancellationToken = default);
    }
}

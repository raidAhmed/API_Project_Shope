using Agricultural.Application.Common;
using Agricultural.Application.DTOs.User_Bank;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IUser_BankService
    {
        Task<IResult<User_BankQueryDto>> Add(User_BankDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<User_BankQueryDto>>> Find(Expression<Func<User_BankQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<User_BankQueryDto>>> Find(DtRequest dtRequest, Expression<Func<User_BankQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<User_BankQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<User_BankQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<User_BankQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<User_BankQueryDto>> Update(User_BankDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(User_BankDto entity, CancellationToken cancellationToken = default);
    }
}

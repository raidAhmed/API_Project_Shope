using Agricultural.Application.Common;
using Agricultural.Application.DTOs.ManufactureCompany;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ManufactureCompany;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IManufactureCompanyService
    {
        Task<IResult<ManufactureCompanyQueryDto>> Add(ManufactureCompanyDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ManufactureCompanyQueryDto>>> Find(Expression<Func<ManufactureCompanyQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ManufactureCompanyQueryDto>>> Find(DtRequest dtRequest, Expression<Func<ManufactureCompanyQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ManufactureCompanyQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<ManufactureCompanyQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<ManufactureCompanyQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<ManufactureCompanyDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<ManufactureCompanyQueryDto>> Update(ManufactureCompanyDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(ManufactureCompanyDto entity, CancellationToken cancellationToken = default);
    }
}

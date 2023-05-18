using Agricultural.Application.Common;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.AdditionalSections;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface IAdditionalSectionsService
    {
        Task<IResult<AdditionalSectionsQueryDto>> Add(AdditionalSectionsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<AdditionalSectionsQueryDto>>> Find(Expression<Func<AdditionalSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<AdditionalSectionsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<AdditionalSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<AdditionalSectionsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<AdditionalSectionsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<AdditionalSectionsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<AdditionalSectionsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<AdditionalSectionsQueryDto>> Update(AdditionalSectionsDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(AdditionalSectionsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MainAndAdditionalClassificationDtoApi>>> GetlistMainWithAdd(CancellationToken cancellationToken = default);
    }
}

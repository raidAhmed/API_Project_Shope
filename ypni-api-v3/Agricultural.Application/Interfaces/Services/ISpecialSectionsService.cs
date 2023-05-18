using Agricultural.Application.Common;
using Agricultural.Application.DTOs.SpecialSections;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SpecialSections;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ISpecialSectionsService
    {
        Task<IResult<SpecialSectionsQueryDto>> Add(SpecialSectionsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SpecialSectionsQueryDto>>> Find(Expression<Func<SpecialSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SpecialSectionsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SpecialSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SpecialSectionsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SpecialSectionsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<SpecialSectionsQueryDto>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SpecialSectionsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);


        Task<IResult<SpecialSectionsQueryDto>> Update(SpecialSectionsDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(SpecialSectionsDto entity, CancellationToken cancellationToken = default);
    }
}

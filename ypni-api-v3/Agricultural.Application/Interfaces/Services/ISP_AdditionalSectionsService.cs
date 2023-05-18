using Agricultural.Application.Common;
using Agricultural.Application.DTOs.Product;
using Agricultural.Application.DTOs.SP_AdditionalSections;
using Agricultural.Application.DTOs.SP_MainClassification;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_AdditionalSections;
using Agricultural.Application.Wrapper;
using System.Linq.Expressions;

namespace Agricultural.Application.Interfaces.Services
{
    public interface ISP_AdditionalSectionsService
    {
        Task<IResult<SP_AdditionalSectionsQueryDto>> Add(SP_AdditionalSectionsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<List<SP_AdditionalSectionsQueryDto>>> Addlistt(List<SP_AdditionalSectionsDtoApi> entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> Find(Expression<Func<SP_AdditionalSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_AdditionalSectionsQueryDto>>> Find(DtRequest dtRequest, Expression<Func<SP_AdditionalSectionsQueryDto, bool>> expression, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> GetAll(CancellationToken cancellationToken = default);
        Task<IResult<DtResult<SP_AdditionalSectionsQueryDto>>> GetAll(DtRequest dtRequest, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AdditionalSectionsDto>>> GetAllForCertainSP(int ServiceProviderId, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> GetById(int Id, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> GetByMainClassficationId(int ServiceProviderId, int AdditionId, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AdditionalSectionsQueryDto>>> GetByIdParnt(int ServiceProviderId, int AdditionId, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<SP_AdditionalSectionsDDlLViewModels>>> GetDDL(CancellationToken cancellationToken = default);
        Task<IResult> Remove(int Id, CancellationToken cancellationToken = default);

        Task<IResult> Addlist(List<SP_AdditionalSectionsDto> entity, CancellationToken cancellationToken = default);

        Task<IResult<SP_AdditionalSectionsQueryDto>> Update(SP_AdditionalSectionsDto entity, CancellationToken cancellationToken = default);
        Task<IResult> ChangeActive(SP_AdditionalSectionsDto entity, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MainAndAdditionalClassificationDtoApi>>> GetByIdSPInfo(int ServId, CancellationToken cancellationToken = default);
        Task<IResult<IEnumerable<MainAndAdditionalClassificationDtoApi>>> GetByIdSPInfoAll(CancellationToken cancellationToken = default);
        // Task<IResult<IEnumerable<MainAndAdditionalClassificationDtoApi>>> GetAllCategory( CancellationToken cancellationToken = default);


    }
}


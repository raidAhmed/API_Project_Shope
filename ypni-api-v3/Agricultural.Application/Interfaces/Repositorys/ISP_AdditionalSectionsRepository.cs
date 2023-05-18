using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_AdditionalSections;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ISP_AdditionalSectionsRepository: IGenericRepository<SP_AdditionalSections>
    {
        Task<IEnumerable<SP_AdditionalSectionsDDlLViewModels>> GetDDL();
    }
}

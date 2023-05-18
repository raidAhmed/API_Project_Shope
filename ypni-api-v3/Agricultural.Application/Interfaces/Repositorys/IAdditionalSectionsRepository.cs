using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.AdditionalSections;
using Agricultural.Application.DTOs.AdditionalSections;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IAdditionalSectionsRepository: IGenericRepository<AdditionalSections>
    {
    
        Task<IEnumerable<AdditionalSectionsDDlLViewModels>> GetDDL();

    }
}

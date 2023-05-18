using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SpecialSections;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ISpecialSectionsRepository: IGenericRepository<SpecialSections>
    {
       
        Task<IEnumerable<SpecialSectionsDDlLViewModels>> GetDDL();

    }
}

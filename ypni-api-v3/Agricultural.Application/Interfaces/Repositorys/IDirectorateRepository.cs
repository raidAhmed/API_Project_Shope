using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Directorate;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IDirectorateRepository: IGenericRepository<Directorate>
    {
       
        Task<IEnumerable<DirectorateDDlLViewModels>> GetDDL();
    }
}

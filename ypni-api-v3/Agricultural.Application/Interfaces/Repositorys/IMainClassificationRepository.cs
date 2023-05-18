using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.MainClassification;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IMainClassificationRepository: IGenericRepository<MainClassification>
    {

        Task<IEnumerable<MainClassificationDDlLViewModels>> GetDDL();
    }
}

using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_MainClassification;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ISP_MainClassificationRepository: IGenericRepository<SP_MainClassification>
    {
        Task<IEnumerable<SP_MainClassificationDDlLViewModels>> GetDDL();
    }
}

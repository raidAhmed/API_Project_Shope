using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SupportRequest;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ISupportRequestRepository: IGenericRepository<SupportRequest>
    {
      
        Task<IEnumerable<SupportRequestDDlLViewModels>> GetDDL();
    }
}

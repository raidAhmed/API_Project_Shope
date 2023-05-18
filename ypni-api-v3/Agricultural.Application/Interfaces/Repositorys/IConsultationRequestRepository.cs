using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ConsultationRequest;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IConsultationRequestRepository: IGenericRepository<ConsultationRequest>
    {
      
        Task<IEnumerable<ConsultationRequestDDlLViewModels>> GetDDL();
    }
}

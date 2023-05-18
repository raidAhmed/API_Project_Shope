using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ProviderEvaluation;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProviderEvaluationRepository: IGenericRepository<ProviderEvaluation>
    {
      
        Task<IEnumerable<ProviderEvaluationDDlLViewModels>> GetDDL();
    }
}

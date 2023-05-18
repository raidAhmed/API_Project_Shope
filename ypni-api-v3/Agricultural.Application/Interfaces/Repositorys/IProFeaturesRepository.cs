using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ProFeatures;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProFeaturesRepository : IGenericRepository<ProFeatures>
    {
      
        Task<IEnumerable<ProFeaturesDDlLViewModels>> GetDDL();
    }
}

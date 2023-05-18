using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_ProFeatures;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ISP_ProFeaturesRepository: IGenericRepository<SP_ProFeatures>
    {
       
        Task<IEnumerable<SP_ProFeaturesDDlLViewModels>> GetDDL();
    }
}
